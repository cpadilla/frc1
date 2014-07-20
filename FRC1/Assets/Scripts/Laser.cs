using UnityEngine;
using System.Collections;

public class Laser :Unit {

	public float m_lifeTime=3.0f;

	public Vector2 velocity;

	public GameObject owner;


	// Use this for initialization
	void Start () {
		Destroy( gameObject, m_lifeTime);

	}
	
	// Update is called once per frame
	void Update () {

		//this.transform.position += this.transform.forward*Time.deltaTime;

		transform.position += transform.up * Time.deltaTime*m_speed;
	}

	void OnTriggerEnter(Collider trigger)
	{
		print (trigger.name);
		Unit unit=trigger.gameObject.GetComponent<Unit>();

		if(unit && unit.tag!= ("Player"))
			unit.Hit();

		Destroy (gameObject);
	}
}
