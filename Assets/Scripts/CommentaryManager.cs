using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Text;
using System.IO;

/// <summary>
/// Manages the generation and display of real-time commentary in the dance battle game.
/// Utilizes Unity's JsonUtility for JSON handling and integrates TTS using Cartesia API.
/// </summary>
public class CommentaryManager : MonoBehaviour
{
    // Singleton Instance
    public static CommentaryManager Instance { get; private set; }

    [Header("UI Elements")]
    public Text commentaryText; // Assign via Inspector

    [Header("AI Settings")]
    private string groqAIApiKey; // Loaded from config.json
    [SerializeField]
    private string groqAIEndpoint = "https://api.groq.com/openai/v1/chat/completions";

    [Header("TTS Settings")]
    private string cartesiaApiKey; // Loaded from config.json
    [SerializeField]
    private string cartesiaVersion = "2024-06-10"; // Assign the appropriate version
    [SerializeField]
    private string cartesiaModelId = "sonic-english";
    [SerializeField]
    private string cartesiaVoiceId = "8eb90615-1780-4809-90c3-76c5d2ecc7d2"; // Assign the desired voice ID
    [SerializeField]
    private string cartesiaLanguage = "en"; // Assign the desired language
    [SerializeField]
    private int cartesiaSampleRate = 44100; // Example sample rate

    [Header("Commentary Settings")]
    [SerializeField]
    private int maxHistory = 5;
    private Queue<string> commentaryHistory = new Queue<string>();

    [Header("Audio Playback")]
    public AudioSource audioSource; // Assign via Inspector

    private string configFilePath;

    void Awake()
    {
        // Implement Singleton Pattern
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        // Ensure AudioSource is assigned
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        // Define the config file path (inside StreamingAssets)
        configFilePath = Path.Combine(Application.dataPath, "config.json");

        // Load the API keys from the JSON file
        LoadAPIKeys();
    }

    /// <summary>
    /// Loads the API keys from config.json
    /// </summary>
    private void LoadAPIKeys()
    {
        if (File.Exists(configFilePath))
        {
            // Read the JSON content from the file
            string jsonContent = File.ReadAllText(configFilePath);

            // Deserialize the JSON into a Config object
            Config config = JsonUtility.FromJson<Config>(jsonContent);

            // Assign the API keys from the config to variables
            groqAIApiKey = config.GROQ_API_KEY;
            cartesiaApiKey = config.CARTESIA_API_KEY;

            Debug.Log("API keys loaded successfully.");
=        }
        else
        {
            Debug.LogError("config.json file not found at: " + configFilePath);
        }
    }

    /// <summary>
    /// Generates commentary based on the current action and past history.
    /// Then initiates TTS to convert the commentary to speech.
    /// </summary>
    /// <param name="currentAction">The current action description.</param>
    public void GenerateCommentary(string currentAction)
    {
        // Create the prompt with past commentary
        Debug.Log("Generating commentary for: " + currentAction);
        string prompt = CreatePrompt(currentAction);
        Debug.Log("Generated Prompt:\n" + prompt);

        // Start the coroutine to get AI commentary
        StartCoroutine(GetAICommentary(prompt));
    }

    /// <summary>
    /// Creates a prompt for the AI by incorporating past commentary.
    /// </summary>
    /// <param name="currentAction">The current action description.</param>
    /// <returns>The complete prompt string.</returns>
    private string CreatePrompt(string currentAction)
    {
        StringBuilder promptBuilder = new StringBuilder();

        // Add past commentary
        promptBuilder.AppendLine("Past Commentary:");
        foreach (var comment in commentaryHistory)
        {
            promptBuilder.AppendLine($"- {comment}");
        }

        // Add current action
        promptBuilder.AppendLine("\nCurrent Action:");
        promptBuilder.AppendLine(currentAction);

        // Add instructions
        promptBuilder.AppendLine("\nProvide exciting and fun commentary accordingly. Keep your commentary terse and brief. Example 1: Kunal stuns the audience with his trademark moonwalk. James better watch out!");

        return promptBuilder.ToString();
    }

    /// <summary>
    /// Coroutine to send a request to Groq AI and receive commentary.
    /// </summary>
    /// <param name="prompt">The prompt for the AI.</param>
    /// <returns></returns>
    private IEnumerator GetAICommentary(string prompt)
    {
        // Define the request payload
        var requestPayload = new GroqRequest
        {
            model = "llama-3.1-70b-versatile", // Updated model name
            messages = new List<Message>
            {
                new Message { role = "user", content = prompt }
            },
            temperature = 0.7f,
            max_tokens = 120
        };

        string jsonData = JsonUtility.ToJson(requestPayload);
        Debug.Log("Request Payload:\n" + jsonData);

        // Create the UnityWebRequest
        UnityWebRequest request = new UnityWebRequest(groqAIEndpoint, "POST");
        byte[] bodyRaw = Encoding.UTF8.GetBytes(jsonData);
        request.uploadHandler = new UploadHandlerRaw(bodyRaw);
        request.downloadHandler = new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");
        request.SetRequestHeader("Authorization", $"Bearer {groqAIApiKey}");

        // Send the request
        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
        {
            Debug.LogError($"Error fetching commentary: {request.error}");
            Debug.LogError($"Response Code: {request.responseCode}");
            Debug.LogError($"Response Body: {request.downloadHandler.text}");
        }
        else
        {
            // Parse the response
            var responseText = request.downloadHandler.text;
            Debug.Log("Response Text:\n" + responseText);
            GroqResponse response = JsonUtility.FromJson<GroqResponse>(responseText);

            if (response != null && response.choices != null && response.choices.Count > 0)
            {
                // Extract the commentary from the response
                string commentary = response.choices[0].message.content.Trim();

                // Add to history
                AddToHistory(commentary);

                // Display the commentary
                DisplayCommentary(commentary);

                // Start TTS for the commentary
                StartCoroutine(GetTTS(commentary));
            }
            else
            {
                Debug.LogError("Invalid response from Groq.");
            }
        }
    }

    /// <summary>
    /// Coroutine to send a request to Cartesia TTS API and receive audio bytes.
    /// </summary>
    /// <param name="text">The text to convert to speech.</param>
    /// <returns></returns>
    private IEnumerator GetTTS(string text)
    {
        // Define the request payload
        var ttsRequest = new CartesiaTTSRequest
        {
            model_id = cartesiaModelId,
            transcript = text,
            voice = new CartesiaVoice
            {
                mode = "id",
                id = cartesiaVoiceId
            },
            output_format = new CartesiaOutputFormat
            {
                container = "raw",
                encoding = "pcm_s16le",
                sample_rate = cartesiaSampleRate
            },
            // Optional parameters
            // duration = 10, // Example: maximum duration in seconds
            // language = cartesiaLanguage
        };

        string jsonData = JsonUtility.ToJson(ttsRequest);
        Debug.Log("TTS Request Payload:\n" + jsonData);

        // Create the UnityWebRequest
        UnityWebRequest request = new UnityWebRequest("https://api.cartesia.ai/tts/bytes", "POST");
        byte[] bodyRaw = Encoding.UTF8.GetBytes(jsonData);
        request.uploadHandler = new UploadHandlerRaw(bodyRaw);
        request.downloadHandler = new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");
        request.SetRequestHeader("X-API-Key", cartesiaApiKey);
        request.SetRequestHeader("Cartesia-Version", cartesiaVersion);

        // Send the request
        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
        {
            Debug.LogError($"Error fetching TTS audio: {request.error}");
        }
        else
        {
            // Get the audio bytes
            byte[] audioBytes = request.downloadHandler.data;
            Debug.Log($"Received {audioBytes.Length} bytes of audio data.");

            // Convert bytes to AudioClip
            AudioClip audioClip = WavUtility.ToAudioClip(audioBytes, 0, "TTS_Audio", cartesiaSampleRate);

            if (audioClip != null)
            {
                // Play the audio
                PlayAudioClip(audioClip);
            }
            else
            {
                Debug.LogError("Failed to convert audio bytes to AudioClip.");
            }
        }
    }

    /// <summary>
    /// Plays the given AudioClip using the assigned AudioSource.
    /// </summary>
    /// <param name="clip">The AudioClip to play.</param>
    private void PlayAudioClip(AudioClip clip)
    {
        if (audioSource != null)
        {
            audioSource.clip = clip;
            audioSource.Play();
            Debug.Log("Playing TTS audio.");
        }
        else
        {
            Debug.LogError("AudioSource not assigned.");
        }
    }

    /// <summary>
    /// Adds a new commentary to the history, maintaining the max history size.
    /// </summary>
    /// <param name="commentary">The commentary to add.</param>
    private void AddToHistory(string commentary)
    {
        if (commentaryHistory.Count >= maxHistory)
        {
            commentaryHistory.Dequeue(); // Remove the oldest commentary
        }
        commentaryHistory.Enqueue(commentary);
    }

    /// <summary>
    /// Displays the commentary in the UI.
    /// </summary>
    /// <param name="commentary">The commentary to display.</param>
    private void DisplayCommentary(string commentary)
    {
        if (commentaryText != null)
        {
            commentaryText.text = commentary;
        }
        else
        {
            Debug.Log("Commentary Text UI element not assigned.");
        }
    }

    // Classes to handle JSON serialization/deserialization

    [System.Serializable]
    public class Config
    {
        public string GROQ_API_KEY;
        public string CARTESIA_API_KEY;
    }

    [System.Serializable]
    public class GroqRequest
    {
        public string model;
        public List<Message> messages;
        public int max_tokens;
        public float temperature;
    }

    [System.Serializable]
    public class Message
    {
        public string role;
        public string content;
    }

    [System.Serializable]
    public class GroqChoice
    {
        public Message message;
        public int index;
        public string finish_reason;
    }

    [System.Serializable]
    public class GroqResponse
    {
        public string id;
        public string @object;
        public int created;
        public string model;
        public List<GroqChoice> choices;
        public Usage usage;
    }

    [System.Serializable]
    public class Usage
    {
        public int prompt_tokens;
        public int completion_tokens;
        public int total_tokens;
    }

    [System.Serializable]
    public class CartesiaTTSRequest
    {
        public string model_id;
        public string transcript;
        public CartesiaVoice voice;
        public CartesiaOutputFormat output_format;
    }

    [System.Serializable]
    public class CartesiaVoice
    {
        public string mode;
        public string id;
    }

    [System.Serializable]
    public class CartesiaOutputFormat
    {
        public string container;
        public string encoding;
        public int sample_rate;
    }
}
