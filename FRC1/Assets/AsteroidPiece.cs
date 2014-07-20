using UnityEngine;
using System.Collections;

public class AsteroidPiece : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider collider)
	{
		Unit entity=collider.GetComponent<Unit>();

		if(entity)
			entity.Hit();

		Destroy(gameObject);
		Destroy(collider.gameObject);
	}
}
