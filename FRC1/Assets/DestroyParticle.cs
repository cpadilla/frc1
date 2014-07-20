using UnityEngine;
using System.Collections;

public class DestroyParticle : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{
	  Destroy(gameObject,this.particleSystem.startLifetime);
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
}
