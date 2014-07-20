using UnityEngine;
using System.Collections;

public class AsteroidPiece : Unit {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other)
	{

		print (other.name);
		switch (other.name) {
		case "EnemyShip":
			Unit enemy= (Unit)other.gameObject.GetComponent<Unit>();
			enemy.Hit();
			break;
		case "Laser":

			gameObject.GetComponent<Unit>().Hit();
			break;
	
		}
		
	}
}
