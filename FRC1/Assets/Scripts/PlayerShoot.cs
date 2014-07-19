using UnityEngine;

using System.Collections;

public class PlayerShoot : MonoBehaviour 
{
	

	
	public GameObject [] 	bulletTypes;
	public GameObject [] 	mainGuns;
	public GameObject [] 	sideGuns; 
	
	[HideInInspector]
	public float 			m_fireRate	=	1f;
	
	private float [] 		m_fireRateMult;

	private float 			m_fireRate	=	1f;
	private float 			m_Timer = 0.0f;
	
	private bool []      	ship_FireType;
	private bool [] 	 	mainGun_FireType;
	private bool []      	sideGun_FireType;
	private bool []		    topGun_FireType;
	
	private GameObject   	nBullet;
	private float 		 	m_fBulletSpeed = 6.0f;
		
	private bool		 	mainGun_stageredFireRight = true;
	private bool 		 	sideGuns_StageredFireRight = true;
	private int 		 	sideGunsSpawnersIndex = 0;

	
	private bool		 doubleGuns_stagaredFire = false;
	private bool 		 doubleGuns_doubleFire = false;
     
	private float 		 m_fBulletSpeed = 1.0f;
	// Use this for initialization
	void Start () 
	{

		ship_FireType = new bool [2];
		ship_FireType[0] = true;
		ship_FireType[1] = false;
		ship_FireType[2] = false;
		
		mainGun_FireType = new bool [2];
		mainGun_FireType[0] = true;
		mainGun_FireType[1] = false;
		
		sideGun_FireType = new bool [2];
		sideGun_FireType[0] = true;
		sideGun_FireType[1] = false;
		
		topGun_FireType = new bool[2];
		topGun_FireType[0] = true;
		topGun_FireType[1] = false;
		 	
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
		
		if(ship_FireTypeIndex == 0)
		{
			ship_FireType[0] = true;
			ship_FireType[1] = false;
			ship_FireType[2] = false;
		}
		else if(ship_FireTypeIndex == 1)
		{
			ship_FireType[0] = false;
			ship_FireType[1] = true;
			ship_FireType[2] = false;
		}
		else
		{
			ship_FireType[0] = false;
			ship_FireType[1] = false;
			ship_FireType[2] = true;
		}		
	}

	private void Fire()
	{
		if(mainGun_stageredFire)
		{
			if(mainGun_stageredFireRight)
			{		
				nBullet= (GameObject)Instantiate(bulletTypes[0],(mainGuns[1].transform.position - transform.forward),transform.rotation);
				mainGun_stageredFireRight = false;
				nBullet.transform.Translate(new Vector3(0,0,m_fBulletSpeed));
			}
			else
			{
				nBullet= (GameObject)Instantiate(bulletTypes[0],(mainGuns[0].transform.position- transform.forward),transform.rotation);
				mainGun_stageredFireRight = true;
				nBullet.transform.Translate(new Vector3(0,0,m_fBulletSpeed));
			}
			

		}
		else if(mainGun_doubleFire)
		{

			
			
			switch(sideGun_FireTypeIndex)
			{
			case 0:
			{
				for(int i = 0; i < sideGunsSpawners.Length;)
				{
					nBullet= (GameObject)Instantiate(bulletTypes[bulletTypesIndex],(sideGunsSpawners[sideGunsSpawnersIndex].transform.position),transform.rotation);
					sideGunsSpawnersIndex++;
					if(sideGunsSpawnersIndex >= 6)
					sideGunsSpawnersIndex = 0;
					return;
				}
				break;
			}
			case 1:
			{
				if(sideGuns_StageredFireRight)
				{
					nBullet= (GameObject)Instantiate(bulletTypes[bulletTypesIndex],(sideGunsSpawners[0].transform.position),transform.rotation);
					nBullet= (GameObject)Instantiate(bulletTypes[bulletTypesIndex],(sideGunsSpawners[1].transform.position),transform.rotation);
					nBullet= (GameObject)Instantiate(bulletTypes[bulletTypesIndex],(sideGunsSpawners[2].transform.position),transform.rotation);
					sideGuns_StageredFireRight = false;
				}
				else
				{
					nBullet= (GameObject)Instantiate(bulletTypes[bulletTypesIndex],(sideGunsSpawners[3].transform.position),transform.rotation);
					nBullet= (GameObject)Instantiate(bulletTypes[bulletTypesIndex],(sideGunsSpawners[4].transform.position),transform.rotation);
					nBullet= (GameObject)Instantiate(bulletTypes[bulletTypesIndex],(sideGunsSpawners[5].transform.position),transform.rotation);
					sideGuns_StageredFireRight = true;
				}
				break;
			}
			}
			
		}
		else if(sideGun_FireType[2])
		{
			switch(sideGun_FireTypeIndex)
			{
				case 0:
				{
					
					break;
				}
			}
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
