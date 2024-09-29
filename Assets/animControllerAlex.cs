using UnityEngine;

public class animControllerAlex : MonoBehaviour
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
        if (Input.GetKeyDown(KeyCode.Q))
        {
            anim.SetTrigger("hiphopTrigger");
        }
        // bd-to-freeze key code 2
        if (Input.GetKeyDown(KeyCode.W))
        {
            anim.SetTrigger("bdToFreezeTrigger");
        }
        // moonwalk key code 3
        if (Input.GetKeyDown(KeyCode.E))
        {
            anim.SetTrigger("moonwalkTrigger");
        }
        // flair key code 4
        if (Input.GetKeyDown(KeyCode.R))
        {
            anim.SetTrigger("flairTrigger");
        }
        // cheer key code 5
        if (Input.GetKeyDown(KeyCode.T))
        {
            anim.SetTrigger("cheerTrigger");
        }
        // bd-swipes
        if (Input.GetKeyDown(KeyCode.Y))
        {
            anim.SetTrigger("bdSwipesTrigger");
        }
        // bd-var1
        if (Input.GetKeyDown(KeyCode.U))
        {
            anim.SetTrigger("bdVar1Trigger");
        }
        // bd-var4
        if (Input.GetKeyDown(KeyCode.I))
        {
            anim.SetTrigger("bdVar4Trigger");
        }
        // cele
        if (Input.GetKeyDown(KeyCode.O))
        {
            anim.SetTrigger("celeTrigger");
        }
        // backflip
        if (Input.GetKeyDown(KeyCode.P))
        {
            anim.SetTrigger("backflipTrigger");
        }
        
    }
}
