using UnityEngine;
using System.Collections;

public class Stage2PowerUpScript : MonoBehaviour {

	private PlayerShoot psScript;
	private GameObject player;
	// Use this for initialization
	
	void Awake()
	{
		psScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerShoot>();
		player = GameObject.FindGameObjectWithTag("Player");
	}
	
	void Start () 
	{
		
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
			psScript.ship_FireTypeIndex = 1;
			Destroy (this.gameObject);
		}
	}
}
