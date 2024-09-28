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

	// Use this for initialization
	void Start ()
	{
		currentPos = this.transform.position;
		InvokeRepeating("MoveTheBox", 5.0f, timeToWait);
	}
	
	// Update is called once per frame
	void Update ()
	{
		this.transform.position = Vector3.MoveTowards (this.transform.position, moveTo, 0.1f);
	}

	void MoveTheBox()
	{
		//Get a new random position within our box
		moveTo = new Vector3((Random.Range(-maxRange, maxRange)),0,Random.Range(-maxRange, maxRange));

		if (moveTo.x < (this.transform.position.x + pos_tolerance) && (moveTo.z < (this.transform.position.z + pos_tolerance)))
		{
			//Advanced checking of tolerances, make a correction if beyond
		}
	}
}
