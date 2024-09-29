using UnityEngine;

public class animController : MonoBehaviour
{
    public Animator anim;
    private bool isAnimating = false;  // Track whether an animation is currently playing
    private int specificStateHash = -1296874448;   
    private bool isInSpecificState = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anim = GetComponent<Animator>();
    }
    
    // Update is called once per frame
    void Update()
    {
        // Get the current state of the animator
        AnimatorStateInfo stateInfo = anim.GetCurrentAnimatorStateInfo(0);
        // You can use the flag to trigger other behaviors
        if (stateInfo.fullPathHash != specificStateHash)
        
        {
            isAnimating = true;  // Block input while animation is playing
        }
        else
        {
            isAnimating = false; // Allow input when in idle state
        }

        // Only allow input if not currently playing an animation
        if (!isAnimating)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                anim.SetTrigger("hiphopTrigger");
                isAnimating = true;  // Set to true after triggering an animation
            }
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                anim.SetTrigger("bdToFreezeTrigger");
                isAnimating = true;
            }
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                anim.SetTrigger("moonwalkTrigger");
                isAnimating = true;
            }
            if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                anim.SetTrigger("flairTrigger");
                isAnimating = true;
            }
            if (Input.GetKeyDown(KeyCode.Alpha5))
            {
                anim.SetTrigger("cheerTrigger");
                isAnimating = true;
            }
            if (Input.GetKeyDown(KeyCode.Alpha6))
            {
                anim.SetTrigger("bdSwipesTrigger");
                isAnimating = true;
            }
            if (Input.GetKeyDown(KeyCode.Alpha7))
            {
                anim.SetTrigger("bdVar1Trigger");
                isAnimating = true;
            }
            if (Input.GetKeyDown(KeyCode.Alpha8))
            {
                anim.SetTrigger("bdVar4Trigger");
                isAnimating = true;
            }
            if (Input.GetKeyDown(KeyCode.Alpha9))
            {
                anim.SetTrigger("celeTrigger");
                isAnimating = true;
            }
            if (Input.GetKeyDown(KeyCode.Alpha0))
            {
                anim.SetTrigger("backflipTrigger");
                isAnimating = true;
            }
        }

    }
}
