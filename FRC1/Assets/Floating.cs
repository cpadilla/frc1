using UnityEngine;
using System.Collections;

public class Floating : Unit {


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider trig)
	{
		print ("I am colliding!");
	}
}
