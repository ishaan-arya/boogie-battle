using UnityEngine;

public class animController : MonoBehaviour
{
    public Animator anim;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // key code 1
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            anim.SetTrigger("hiphopTrigger");
        }
        // bd-to-freeze key code 2
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            anim.SetTrigger("bdToFreezeTrigger");
        }
        // moonwalk key code 3
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            anim.SetTrigger("moonwalkTrigger");
        }
        // flair key code 4
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            anim.SetTrigger("flairTrigger");
        }
        // cheer key code 5
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            anim.SetTrigger("cheerTrigger");
        }
        // bd-swipes
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            anim.SetTrigger("bdSwipesTrigger");
        }
        // bd-var1
        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            anim.SetTrigger("bdVar1Trigger");
        }
        // bd-var4
        if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            anim.SetTrigger("bdVar4Trigger");
        }
        // cele
        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            anim.SetTrigger("celeTrigger");
        }
        // backflip
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            anim.SetTrigger("backflipTrigger");
        }
        
    }
}
