using UnityEngine;
using System.Collections;

public class Stage3Powerup : MonoBehaviour {
	
	private PlayerShoot psScript;
	// Use this for initialization
	
	void Awake()
	{
		psScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerShoot>();
		
	}
	
	void Start () {
	
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
	void OnTriggerEnter(Collider coll)
	{
		print ("Hit player");
		if(coll.name == "Player")
		{
			psScript.ship_FireTypeIndex = 2;
			Destroy (this.gameObject);
		}
	}
}
