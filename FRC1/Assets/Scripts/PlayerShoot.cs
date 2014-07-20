using UnityEngine;

using System.Collections;
using System.Collections.Generic;

public class PlayerShoot : MonoBehaviour 
{
	
	public static PlayerShoot Instance;
	
	public GameObject [] 	bulletTypes;
	public GameObject []	mainGunSpawners;
	public GameObject []    sideGunsSpawners;
	public GameObject []	topGunsSpawners;
	public ParticleSystem 	muzzleFlash;
	public GameObject		stage2;
	public GameObject		stage3;
	public int 				bulletTypesIndex = 0;
	
	public int 				ship_FireTypeIndex = 0;
	
	public int 				mainGunFireTypeIndex = 0;
	
	public int 				sideGun_FireTypeIndex = 0;
	
	public int 				topGunFireTypeIndex = 0;
	
	public int				m_fireRateIndex = 0;
	
	private float [] 		m_fireRateMult;
	
	
	private float 			m_Timer = 0.0f;
	private float 			m_fireRate = 1.0f;
	
	private bool []      	ship_FireType;
	private bool [] 	 	mainGun_FireType;
	private bool []      	sideGun_FireType;
	private bool []		    topGun_FireType;
	private ParticleSystem [] particleClones;
	private GameObject   	nBullet;

	
	private bool		 	mainGun_stageredFireRight = true;
	private bool 		 	sideGuns_StageredFireRight = true;
	private bool 			topGuns_StageredFireRight = true;
	private bool			stage2Set = false;
	private bool 			stage3Set = false;
	private int 		 	sideGunsSpawnersIndex = 0;
	


	public AudioClip[] shootSFX;
	public List<AudioSource> sources;

	public int sfxCount=0;

	
	
	void Awake()
	{
		Instance = this;
	}
	
	
	// Use this for initialization
	void Start () 
	{
		
		ship_FireType = new bool [3];
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
		m_fireRateMult[0] = 3f;
		m_fireRateMult[1] = 6f;
		m_fireRateMult[2] = 9f;


        }
	
	// Update is called once per frame
	void Update () 
	{
		m_Timer += Time.deltaTime * m_fireRateMult[m_fireRateIndex];

                // If player shoots
        if(Input.GetMouseButton(0) && m_Timer >=  m_fireRate)
        {
			Fire ();
			m_Timer = 0;
				
		////Random i
		//int i =Random.Range(0,shootSFX.Length);
		//
		//if(sources[0].isPlaying)
		//{
		//	sources[1].clip= shootSFX[i];
		//	sources[1].Play();
		//}
		//
		//else
		//{
		//	sources[0].clip= shootSFX[i];
		//	sources[0].Play();
		//}
		//
		
		}	

		Testing();
		
		if(ship_FireTypeIndex == 0)
		{
			ship_FireType[0] = true;
			ship_FireType[1] = false;
			stage2.SetActive(false);
			ship_FireType[2] = false;
			stage3.SetActive(false);
		}
		else if(ship_FireTypeIndex == 1)
		{
			ship_FireType[0] = false;
			ship_FireType[1] = true;
			stage2.SetActive(true);
			GameplayUI.getInstance().UpdateWeaponIcon(1);
			ship_FireType[2] = false;
		}
		else
		{
			ship_FireType[0] = false;
			ship_FireType[1] = false;
			ship_FireType[2] = true;
			stage3.SetActive(true);
			GameplayUI.getInstance().UpdateWeaponIcon(2);	
		}	
	}
	
	private void Fire()
	{
		if(ship_FireTypeIndex == 0)
		{
                      
			switch(mainGunFireTypeIndex)
			{
				case 0:
				{
					if(mainGun_stageredFireRight)
					{		
						nBullet= (GameObject)Instantiate(bulletTypes[bulletTypesIndex],(mainGunSpawners[1].transform.position),transform.rotation);
						mainGun_stageredFireRight = false;				
                              
					}
					else
					{
						nBullet= (GameObject)Instantiate(bulletTypes[bulletTypesIndex],(mainGunSpawners[0].transform.position),transform.rotation);
						mainGun_stageredFireRight = true;
						
					}
					 break;
				}
				case 1:
				{
					nBullet= (GameObject)Instantiate(bulletTypes[bulletTypesIndex],(mainGunSpawners[1].transform.position ),transform.rotation);
					nBullet= (GameObject)Instantiate(bulletTypes[bulletTypesIndex],(mainGunSpawners[0].transform.position),transform.rotation);
					break;
				}
			}
		}	
		
		else if(ship_FireTypeIndex == 1)
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
		else if(ship_FireTypeIndex == 2)
		{
			switch(topGunFireTypeIndex)
			{
				case 0:
				{
					if(topGuns_StageredFireRight)
					{
					nBullet= (GameObject)Instantiate(bulletTypes[bulletTypesIndex],(topGunsSpawners[1].transform.position),transform.rotation);
						topGuns_StageredFireRight = false;
					}
					else
					{
					nBullet= (GameObject)Instantiate(bulletTypes[bulletTypesIndex],(topGunsSpawners[0].transform.position),transform.rotation);
						topGuns_StageredFireRight = true;
					}
					break;
				}
			}
		}
		
        
	}

        
	
	private void Testing()
	{
		if(Input.GetKeyDown(KeyCode.V))
		{
			ship_FireTypeIndex++;
			
			if(ship_FireTypeIndex >= 2)
				ship_FireTypeIndex = 0;
			else if(ship_FireTypeIndex < 0)
			{
				ship_FireTypeIndex = 2;
			}
		}
		
		else if(Input.GetKeyDown(KeyCode.B))
		{
			if(mainGunFireTypeIndex == 0)
			{
				mainGunFireTypeIndex = 1;
			}
			else
			{
				mainGunFireTypeIndex = 0;
			}
		}
		
	  else if(Input.GetKeyDown(KeyCode.M))
		{
			if(sideGun_FireTypeIndex == 0)
			{
				sideGun_FireTypeIndex = 1;
			}
			else
			{
				sideGun_FireTypeIndex = 0;
			}
		}
		
		else if(Input.GetKeyDown(KeyCode.N))
		{
			if(topGunFireTypeIndex == 0)
			{
				topGunFireTypeIndex = 1;
			}
			else
			{
				topGunFireTypeIndex = 0;
			}
		}
		
		else if(Input.GetKeyDown(KeyCode.Comma))
		{
			if(bulletTypesIndex == 0)
			{
				bulletTypesIndex = 1;
			}
			else
			{
				bulletTypesIndex = 0;
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
