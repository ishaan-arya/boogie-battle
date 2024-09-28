using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtThis : MonoBehaviour
{
	public Transform lookAtTarget;

	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		transform.LookAt (lookAtTarget);
	}
}
