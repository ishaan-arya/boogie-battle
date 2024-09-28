using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiscoBox : MonoBehaviour
{
    public Vector3 moveTo;
    public Vector3 currentPos;
    public float pos_tolerance;
    public float maxRange;
    public float timeToWait;
    public float moveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
        currentPos = this.transform.position;
        InvokeRepeating("MoveTheBox", 5.0, timeToWait);

    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = Vector3.MoveTowards(this.transform.position, moveTo, 0.1f);
    }

    void MoveTheBox()
    {
        moveTo = new Vector3(Random.Range(-maxRange, maxRange), 0, Random.Range(-maxRange, maxRange));
    }


}
