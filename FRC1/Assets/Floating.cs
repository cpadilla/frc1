using UnityEngine;
using System.Collections;

public class Floating : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider trig)
	{
		Unit unit= trig.GetComponent<Unit>();

		if(unit)
			unit.Hit();

        //if(trig.gameObject.tag == "Player")
        //    Destroy (gameObject);
	}
}
