using UnityEngine;

/// <summary>
/// Controls animation triggers and initiates commentary generation based on user input.
/// </summary>
public class AnimController : MonoBehaviour
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
        // Check for key presses and trigger corresponding animations and commentary
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            TriggerAction("hiphopTrigger", "Ishaan performs a hiphop dance move");
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            TriggerAction("bdToFreezeTrigger", "Ishaan hits a breakdance freeze");
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            TriggerAction("moonwalkTrigger", "Ishaan hits a moonwalk");
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
            TriggerAction("bdSwipesTrigger", "Ishaan executes impressive breakdance swipes");
        }
        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            TriggerAction("bdVar1Trigger", "Ishaan showcases a breakdance move");
        }
        if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            TriggerAction("bdVar4Trigger", "Ishaan masters a breakdance move");
        }
        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            TriggerAction("celeTrigger", "Ishaan celebrates with a fantastic move");
        }
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            TriggerAction("backflipTrigger", "Ishaan performs a daring backflip");
        }
    }

    /// <summary>
    /// Triggers the specified animation and initiates commentary generation.
    /// </summary>
    /// <param name="triggerName">The name of the animation trigger.</param>
    /// <param name="commentary">The commentary text to generate.</param>
    private void TriggerAction(string triggerName, string commentary)
    {
        if (anim != null)
        {
            anim.SetTrigger(triggerName);
            Debug.Log($"Animation Triggered: {triggerName}");
        }
        else
        {
            Debug.LogError("Animator not assigned.");
        }

        // Initiate commentary generation without waiting for it to complete
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
