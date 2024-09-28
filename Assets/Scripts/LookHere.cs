using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookHere : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform target;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(target);
    }
}
