using UnityEngine;
using System.Collections;

public class DestroyParticle : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(!this.particleSystem.isPlaying)
		{
			Destroy(this.gameObject);
		}
	}
}
