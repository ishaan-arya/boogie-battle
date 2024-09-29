using UnityEngine;
using System.Collections;

/// <summary>
/// Controls animation triggers and initiates commentary generation based on user input.
/// </summary>
public class AnimControllerKunal : MonoBehaviour
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
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            TriggerAction("hiphopTrigger", "Ishaan performs a hiphop dance move");
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            TriggerAction("bdToFreezeTrigger", "Ishaan hits the crowd with a freeze move");
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            TriggerAction("moonwalkTrigger", "Ishaan showcases an impressive moonwalk");
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            TriggerAction("flairTrigger", "Ishaan adds some flashy flair moves");
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            TriggerAction("cheerTrigger", "Ishaan cheers the crowd with energy");
        }
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            TriggerAction("bdSwipesTrigger", "Ishaan executes an impressive swipe");
        }
        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            TriggerAction("bdVar1Trigger", "Ishaan executes a breakdance move");
        }
        if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            TriggerAction("bdVar4Trigger", "Ishaan executes a breakdance move");
        }
        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            TriggerAction("celeTrigger", "Ishaan starts celebrating");
        }
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            TriggerAction("backflipTrigger", "Ishaan performs a daring backflip");
        }
    }

    /// <summary>
    /// Triggers the specified animation and initiates commentary generation.
    /// Also updates the player's score with a random value between minScore and maxScore.
    /// </summary>
    /// <param name="triggerName">The name of the animation trigger.</param>
    /// <param name="commentary">The commentary text to generate.</param>
    /// <summary>
    /// Triggers the specified animation and initiates commentary generation.
    /// Also updates Player 2's score with a random value between minScore and maxScore.
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

        // Initiate commentary generation asynchronously
        if (CommentaryManager.Instance != null)
        {
            CommentaryManager.Instance.GenerateCommentary(commentary);
        }

        // Generate a random score between minScore and maxScore
        int earnedPoints = Random.Range(minScore, maxScore + 1);

        // Add the earned points to Player 2's score
        if (GameManager.Instance != null)
        {
            GameManager.Instance.AddScorePlayer2(earnedPoints);
        }
    }
    
}
