using UnityEngine;

using System.Collections;

public class PlayerShoot : MonoBehaviour {

	
	public GameObject [] 	bulletTypes;
	public GameObject [] 	mainGuns;
	public GameObject [] 	sideGuns; 
	
	[HideInInspector]
	public float 			m_fireRate	=	1f;
	
	private float [] 		m_fireRateMult;
	private int				m_fireRateIndex = 0; 	
	private float 			m_Timer=0.0f;

	//GameObject player= GetComponent<Player>;

	
	private GameObject   nBullet;
	private bool		 mainGun_stageredFire = true;
	private bool 		 mainGun_doubleFire = false;
	private bool		 mainGun_stageredFireRight = true;
	
	private bool		 doubleGuns_stagaredFire = false;
	private bool 		 doubleGuns_doubleFire = false;
     
	private float 		 m_fBulletSpeed = 1.0f;
	// Use this for initialization
	void Start () 
	{
		m_fireRateMult = new float[3];
		m_fireRateMult[0] = 2.5f;
		m_fireRateMult[1] = 5.0f;
		m_fireRateMult[2] = 7.5f;
	}
	
	// Update is called once per frame
	void Update () 
	{
		m_Timer += Time.deltaTime * m_fireRateMult[m_fireRateIndex];
		
		if(Input.GetMouseButton(0) && m_Timer >=  m_fireRate)
		{
			Fire ();
			m_Timer = 0;
		}
		Testing();
		
		
	}

	private void Fire()
	{
		if(mainGun_stageredFire)
		{
			if(mainGun_stageredFireRight)
			{		
				nBullet= (GameObject)Instantiate(bulletTypes[0],(mainGuns[1].transform.position - transform.forward),transform.rotation);
				nBullet.GetComponent<Laser>().owner= gameObject;

				mainGun_stageredFireRight = false;
				nBullet.transform.Translate(new Vector3(0,0,m_fBulletSpeed));
			}
			else
			{
				nBullet= (GameObject)Instantiate(bulletTypes[0],(mainGuns[0].transform.position- transform.forward),transform.rotation);
				nBullet.GetComponent<Laser>().owner= gameObject;

				mainGun_stageredFireRight = true;
				nBullet.transform.Translate(new Vector3(0,0,m_fBulletSpeed));
			}
			

		}
		else if(mainGun_doubleFire)
		{
			nBullet= (GameObject)Instantiate(bulletTypes[0],(mainGuns[1].transform.position),transform.rotation);
			nBullet.GetComponent<Laser>().owner= gameObject;

			nBullet= (GameObject)Instantiate(bulletTypes[0],(mainGuns[0].transform.position),transform.rotation);
			nBullet.GetComponent<Laser>().owner= gameObject;

		}
			
	}
	
	private void Testing()
	{
		if(Input.GetKeyDown(KeyCode.B))
		{
			if(mainGun_stageredFire)
			{
				mainGun_stageredFire = false;
				mainGun_doubleFire = true;
			}
		}
		else if (Input.GetKeyDown(KeyCode.Alpha0))
		{
			m_fireRateIndex  = 0;
		}
		else if (Input.GetKeyDown(KeyCode.Alpha1))
		{
			m_fireRateIndex  = 1;
		}
		else if (Input.GetKeyDown(KeyCode.Alpha2))
		{
			m_fireRateIndex  = 2;
		}
	}
}
