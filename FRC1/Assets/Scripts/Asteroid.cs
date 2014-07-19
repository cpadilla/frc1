using UnityEngine;
using System.Collections;

public class Asteroid : Unit {



	//
	// Use this for initialization
	void Start () {
	
		m_health=3;
	}
	
	// Update is called once per frame
	void Update () {


		//transform.Rotate(new Vector3(0,1,1),Space.World);
		transform.Translate(m_velocity*Time.deltaTime);
	
		if(m_health<=0)
			Destroy(this.gameObject);

	}

	void OnTriggerEnter(Collider collision)
	{
		print ("Imwork");
		//if(collision.gameObject.tag=="Proj")
		//	Destroy(this.gameObject);


	}

	void OnDestroy()
	{
		FindObjectOfType<Player>().m_score+=100;
	
	}

}
