using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    // Singleton Instance
    public static GameManager Instance { get; private set; }

    [Header("Game Settings")]
    [SerializeField]
    private int initialScore = 0;

    private int playerScore;

    // Property to access the player's score
    public int PlayerScore
    {
        get { return playerScore; }
        private set
        {
            if (playerScore != value)
            {
                playerScore = value;
                // Invoke the event
                OnScoreChanged?.Invoke(playerScore);
            }
        }
    }

    // Event triggered when the score changes
    public event Action<int> OnScoreChanged;

    void Awake()
    {
        // Implement Singleton Pattern
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Persist across scenes
            InitializeGame();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// Initializes game variables.
    /// </summary>
    private void InitializeGame()
    {
        PlayerScore = initialScore;
        Debug.Log($"Game Initialized. Starting Score: {PlayerScore}");
    }

    /// <summary>
    /// Adds a specified amount to the player's score.
    /// </summary>
    /// <param name="points">Points to add.</param>
    public void AddScore(int points)
    {
        PlayerScore += points;
        Debug.Log($"Score Added: {points}. New Score: {PlayerScore}");
    }

    /// <summary>
    /// Resets the player's score to the initial value.
    /// </summary>
    public void ResetScore()
    {
        PlayerScore = initialScore;
        Debug.Log($"Score Reset. Current Score: {PlayerScore}");
    }
}
