using UnityEngine;
using System.Collections;

public class Laser :Unit {

	public float m_lifeTime=3.0f;

	public Vector2 velocity;


	// Use this for initialization
	void Start () {
		gameObject.name = "Laser";
		//transform.parent = GameObject.Find ("LaserContainer").transform;
		Destroy( gameObject, m_lifeTime);


	}
	
	// Update is called once per frame
	void Update () {

		//this.transform.position += this.transform.forward*Time.deltaTime;

		transform.position += transform.up * Time.deltaTime*m_speed;
	}

	void OnTriggerEnter(Collider trigger)
	{
		trigger.gameObject.GetComponent<Unit>().Hit();

		Destroy (this.gameObject);
	}
}


//1E 10E
//2E 3
//3E 1

//Laser
//rapidfire
//burst
