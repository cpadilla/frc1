using UnityEngine;

using System.Collections;

public class PlayerShoot : MonoBehaviour {

	//
	//Bullet to shoot
	public GameObject bullet;

	//Velocity?
	public Vector2 velocity;
	
	//Fire rate
	public float m_fireRate	=	0.000001f;
	float m_timer=0.0f;

	//GameObject player= GetComponent<Player>;
	public GameObject[]  mainGuns;
	
	private GameObject   nBullet;
	private bool		 RightGun = false;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
		if(Input.GetButton("Fire1") && Time.time >= Time.deltaTime + m_fireRate )
		{
			Fire ();		
		}
	}

	private void Fire()
	{
		if(RightGun)
		{		
			nBullet= (GameObject)Instantiate(bullet,(mainGuns[1].transform.position),transform.rotation);
			RightGun = false;
		}
		else
		{
			nBullet= (GameObject)Instantiate(bullet,(mainGuns[0].transform.position),transform.rotation);
			RightGun = true;
		}
		
		
		nBullet.transform.Translate(new Vector3(0,0,1));
		
		
		//nBullet.transform.Rotate(new Vector3(0,90,0));
		
		m_timer=0.0f;
	}
}
