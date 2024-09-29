using UnityEngine;

/// <summary>
/// Controls animation triggers and initiates commentary generation based on user input.
/// </summary>
public class animControllerKunal : MonoBehaviour
{
    public Animator anim;

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
            TriggerAction("hiphopTrigger", "Kunal performs a hiphop dance move");
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            TriggerAction("bdToFreezeTrigger", "Kunal executes a moonwalk");
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            TriggerAction("moonwalkTrigger", "Kunal showcases an impressive moonwalk");
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            TriggerAction("flairTrigger", "Kunal adds some flashy flair moves");
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            TriggerAction("cheerTrigger", "Kunal cheers the crowd with energy");
        }
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            TriggerAction("bdSwipesTrigger", "Kunal executes impressive BD swipes");
        }
        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            TriggerAction("bdVar1Trigger", "Kunal showcases BD variant 1");
        }
        if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            TriggerAction("bdVar4Trigger", "Kunal masters BD variant 4");
        }
        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            TriggerAction("celeTrigger", "Kunal celebrates with a fantastic move");
        }
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            TriggerAction("backflipTrigger", "Kunal performs a daring backflip");
        }
    }

    /// <summary>
    /// Triggers the specified animation and initiates commentary generation.
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
    }
}
