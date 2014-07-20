using UnityEngine;
using System.Collections;

public class Laser :Unit {

	public float m_lifeTime=3.0f;

	public Vector2 velocity;


        // Factory for laser
        public static GameObject CreateLaser(string owner, GameObject bulletType, Vector3 postion, Quaternion rotation)
        {
            GameObject obj = (GameObject)Instantiate(bulletType,postion,rotation);

            // Try to set the owner with the provided value
            try { obj.tag = owner; }
            catch { obj.tag = "Laser"; }

            return obj;
        }

	// Use this for initialization
	void Start () {
		gameObject.name = "Laser";
		transform.parent = GameObject.Find ("LaserContainer").transform;
		Destroy( gameObject, m_lifeTime);


	}
	
	// Update is called once per frame
	void Update () {

		//this.transform.position += this.transform.forward*Time.deltaTime;

		transform.position += transform.up * Time.deltaTime*m_speed;
	}

	void OnTriggerEnter(Collider trigger)
	{
		switch(trigger.gameObject.name)
		{
		case"Asteroid_Orig":
				Unit ast=  trigger.gameObject.GetComponent<Unit>();
				ast.Hit ();
			break;
		case "Asteroid_Piece":
			Destroy(trigger.gameObject);
			break;
		}

	}
}


//1E 10E
//2E 3
//3E 1

//Laser
//rapidfire
//bu
