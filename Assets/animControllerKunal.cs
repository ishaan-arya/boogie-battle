using UnityEngine;

public class animController : MonoBehaviour
{
    public Animator anim;
    private bool isAnimating = false;  // Track whether an animation is currently playing

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // Get the current state of the animator
        // Check if an animation is playing
        if (isAnimating)
        {
            AnimatorStateInfo stateInfo = anim.GetCurrentAnimatorStateInfo(0);
            print(stateInfo.normalizedTime);  // Print the normalized time of the current animation state
            // Check if the animation has finished (normalizedTime >= 1 means it finished)
            if (stateInfo.normalizedTime >= 1.0f && !anim.IsInTransition(0))
            {
                isAnimating = false;  // Re-enable input once animation finishes
            }
            return;
        }
        else {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                anim.SetTrigger("hiphopTrigger");
                isAnimating = true; 
            }
            // bd-to-freeze key code 2
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                anim.SetTrigger("bdToFreezeTrigger");
                isAnimating = true;
            }
            // moonwalk key code 3
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                anim.SetTrigger("moonwalkTrigger");
                isAnimating = true;
            }
            // flair key code 4
            if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                anim.SetTrigger("flairTrigger");
                isAnimating = true;
            }
            // cheer key code 5
            if (Input.GetKeyDown(KeyCode.Alpha5))
            {
                anim.SetTrigger("cheerTrigger");
                isAnimating = true;
            }
            // bd-swipes
            if (Input.GetKeyDown(KeyCode.Alpha6))
            {
                anim.SetTrigger("bdSwipesTrigger");
                isAnimating = true;
            }
            // bd-var1
            if (Input.GetKeyDown(KeyCode.Alpha7))
            {
                anim.SetTrigger("bdVar1Trigger");
                isAnimating = true;
            }
            // bd-var4
            if (Input.GetKeyDown(KeyCode.Alpha8))
            {
                anim.SetTrigger("bdVar4Trigger");
                isAnimating = true;
            }
            // cele
            if (Input.GetKeyDown(KeyCode.Alpha9))
            {
                anim.SetTrigger("celeTrigger");
                isAnimating = true;
            }
            // backflip
            if (Input.GetKeyDown(KeyCode.Alpha0))
            {
                anim.SetTrigger("backflipTrigger");
                isAnimating = true;
            }
        }
            // key code 1
    }
}
