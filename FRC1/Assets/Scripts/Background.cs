using UnityEngine;
using System.Collections;

public class Background : MonoBehaviour 
{
	
	
	public ParticleSystem background_StarSystem;
	void Awake()
	{
		
	}
	
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Player.Instance.moving)
		{
			background_StarSystem.gravityModifier = .5f;
		}
		else
		{
			background_StarSystem.gravityModifier = .1f;
		}
	}
}
