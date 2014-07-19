using UnityEngine;
using System.Collections;

public class Asteroid : Unit {


	//
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {


		//transform.Rotate(new Vector3(0,1,1),Space.World);
		transform.Translate(m_velocity*Time.deltaTime);
	

	}

	void OnTriggerEnter(Collider collision)
	{
		print ("Imwork");
		if(collision.gameObject.CompareTag("Proj"))
			Destroy(this.gameObject);

	}
}
