using UnityEngine;

/// <summary>
/// Controls animation triggers and initiates commentary generation based on user input.
/// </summary>
public class AnimControllerAlex : MonoBehaviour
{
    public Animator anim;

    [Header("Score Settings")]
    [SerializeField]
    private int minScore = 6;
    [SerializeField]
    private int maxScore = 10;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();

        if (anim == null)
        {
            Debug.LogError("Animator component not found on this GameObject.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Detect key presses and trigger corresponding actions
        if (Input.GetKeyDown(KeyCode.Q))
        {
            TriggerAction("hiphopTrigger", "Alex performs a hiphop dance move");
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            TriggerAction("bdToFreezeTrigger", "Alex executes a moonwalk");
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            TriggerAction("moonwalkTrigger", "Alex showcases an impressive moonwalk");
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            TriggerAction("flairTrigger", "Alex adds some flashy flair moves");
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            TriggerAction("cheerTrigger", "Alex cheers the crowd with energy");
        }
        if (Input.GetKeyDown(KeyCode.Y))
        {
            TriggerAction("bdSwipesTrigger", "Alex executes impressive BD swipes");
        }
        if (Input.GetKeyDown(KeyCode.U))
        {
            TriggerAction("bdVar1Trigger", "Alex showcases BD variant 1");
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            TriggerAction("bdVar4Trigger", "Alex masters BD variant 4");
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            TriggerAction("celeTrigger", "Alex celebrates with a fantastic move");
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            TriggerAction("backflipTrigger", "Alex performs a daring backflip");
        }
    }

    /// <summary>
    /// Triggers the specified animation and initiates commentary generation.
    /// Also updates the player's score with a random value between minScore and maxScore.
    /// </summary>
    /// <param name="triggerName">The name of the animation trigger.</param>
    /// <param name="commentary">The commentary text to generate.</param>
    private void TriggerAction(string triggerName, string commentary)
    {
        // Trigger the animation
        if (anim != null)
        {
            anim.SetTrigger(triggerName);
            Debug.Log($"Animation Triggered: {triggerName}");
        }
        else
        {
            Debug.LogError("Animator not assigned.");
        }

        // Initiate commentary generation asynchronously
        if (CommentaryManager.Instance != null)
        {
            CommentaryManager.Instance.GenerateCommentary(commentary);
        }
        else
        {
            Debug.LogError("CommentaryManager instance not found.");
        }

        // Generate a random score between minScore and maxScore
        int earnedPoints = Random.Range(minScore, maxScore + 1); // Inclusive upper bound
        Debug.Log($"Points Earned: {earnedPoints}");

        // Add the earned points to the player's score
        if (GameManager.Instance != null)
        {
            GameManager.Instance.AddScore(earnedPoints);
        }
        else
        {
            Debug.LogError("GameManager instance not found.");
        }
    }
}
