using UnityEngine;
using System.Collections;

public class Background : MonoBehaviour 
{
	
	private Player m_cPlayer;
	
	public ParticleSystem background_StarSystem;
	
	public GameObject background_SmallPlanet;
	public GameObject background_LargePlanet;
	public GameObject playerShip;
	
	void Awake()
	{
		m_cPlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
	}
	
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(m_cPlayer.moving)
		{
			background_StarSystem.gravityModifier = .2f;
		}
		else
		{
			background_StarSystem.gravityModifier = 0f;
		}
	}
}
