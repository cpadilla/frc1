using UnityEngine;

using System.Collections;
using System.Collections.Generic;

public class PlayerShoot : MonoBehaviour 
{
	
	
	
	public GameObject [] 	bulletTypes;
	public GameObject []	mainGunSpawners;
	public GameObject []    sideGunsSpawners;
	
        //////////////////////////////////////////
        //        Code Christofer added         //
        //////////////////////////////////////////

        // Right now we have 8 guns in this order
        //
        // [side]      [side]
        // 1 2 3        6 7 8
        //        4  5
        //       [main]
	public List<GameObject>	allGunSpawners;

        // Firing Pattern struct
        class FiringPattern
        {
            public FiringPattern(List<int>[] gunSequence) { this.gunSequence = gunSequence; }
            private int _sequenceIndex;
            public int sequenceIndex
            {
                get { return _sequenceIndex; }
                set
                {
                    // loop index back to zero if greater than length
                    _sequenceIndex = (value < gunSequence.Length) ? value : 0;
                }
            }
            public List<int>[] gunSequence;
        }
        private Dictionary<int, FiringPattern> firingPatterns = new Dictionary<int,FiringPattern>();

        // This is an index into the bulletTypes array for our current bullet type
        public int currentBulletType = 0;
	
        //////////////////////////////////////////
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
	
	private GameObject   	nBullet;
	//private float 		 	m_fBulletSpeed = 6.0f;
	//
	//private bool		 	mainGun_stageredFireRight = true;
	//private bool 		 	sideGuns_StageredFireRight = true;
	//
	//private int 		 	sideGunsSpawnersIndex = 0;
	//
	//
	//private bool		 doubleGuns_stagaredFire = false;
	
	
	
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

                #region Create Firing Patterns

                    #region Firing Pattern 1
                    // Firing Pattern 1
                    // 00001000
                    // 00010000
                    List<int>[] fp_1 = new List<int>[8];
                    for (int i = 0; i< 8; i++)
                    {
                        List<int> l = new List<int>();
                        if (i==3)
                        {
                            l.Add((i%2==0)?1:0);
                            l.Add((i%2==0)?0:1);
                        }
                        else
                        {
                            l.Add(0);
                            l.Add(0);
                        }
                        fp_1[i] = l;
                    }
                    FiringPattern fp1 = new FiringPattern(fp_1);
                    firingPatterns.Add(0, fp1);
                    #endregion

                    #region Firing Pattern 2
                    // Firing Pattern 2
                    // 10101010
                    // 01010101
                    List<int>[] fp_2 = new List<int>[8];
                    for (int i = 0; i< 8; i++)
                    {
                        List<int> l = new List<int>();
                        l.Add((i%2==0)?1:0);
                        l.Add((i%2==0)?0:1);
                        fp_2[i] = l;
                    }
                    FiringPattern fp2 = new FiringPattern(fp_2);
                    firingPatterns.Add(1, fp2);
                    #endregion
                #endregion
        }
	
	// Update is called once per frame
	void Update () 
	{
		m_Timer += Time.deltaTime * m_fireRateMult[m_fireRateIndex];

                // If player shoots
                if(Input.GetMouseButton(0) && m_Timer >=  m_fireRate)
                {
					Fire ();

                    #region Update Firing Sequence
                    // update sequenceindex of our firing patterns
                        foreach (FiringPattern fp in firingPatterns.Values)
                        {
                            // add firing rate logic here
                            //if (++fp.sequenceIndex > fp.gunSequence.Length) fp.sequenceIndex = 0;
                            fp.sequenceIndex++;
                        }
                    #endregion

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

        //foreach (GameObject gun in allGunSpawners)
        for (int i = 1; i < 8; i++ )
        {
            if (isFiring(i))
            {

				{ Laser.CreateLaser("PlayerBullet",                   /* tag = "PlayerBullet" */
                    bulletTypes[currentBulletType],                 /* old bulletTypes[0] */
                    (allGunSpawners[i].transform.position - transform.forward),   /* old (mainGuns[1].transform.position - transform.forward) code*/
                    transform.rotation);
					m_Timer=0;
				}/* old transform.rotation */
            }
        }

        #region OldCode
        /* // Sorry, we're gonna refactor this
		if(ship_FireTypeIndex == 0)
		{
                        // Manually merged - Chris 1:00 AM
			//if(mainGun_stageredFireRight)
			//{		
			//	nBullet= (GameObject)Instantiate(bulletTypes[0],(mainGuns[1].transform.position - transform.forward),transform.rotation);
                        //        nBullet.tag = "PlayerBullet";
			//	nBullet.GetComponent<Laser>().owner= gameObject;

			//	mainGun_stageredFireRight = false;
			//	nBullet.transform.Translate(new Vector3(0,0,m_fBulletSpeed));
			//}
			//else
			switch(mainGunFireTypeIndex)
			{
				case 0:
				{
					if(mainGun_stageredFireRight)
					{		
					//nBullet= (GameObject)Instantiate(bulletTypes[bulletTypesIndex],(mainGunSpawners[1].transform.position - transform.forward),transform.rotation);
                                        nBullet = Laser.CreateLaser("PlayerBullet",                     // The owner
                                            bulletTypes[bulletTypesIndex],                              // The bullet type
                                            (mainGunSpawners[1].transform.position - transform.forward),// The position
                                            transform.rotation);                                        // The rotation
						mainGun_stageredFireRight = false;
					nBullet.tag="PlayerProj";
					}
					else
					{
					//nBullet= (GameObject)Instantiate(bulletTypes[bulletTypesIndex],(mainGunSpawners[0].transform.position- transform.forward),transform.rotation);
                                        nBullet = Laser.CreateLaser("PlayerBullet",                     // The owner
                                            bulletTypes[bulletTypesIndex],                              // The bullet type
                                            (mainGunSpawners[(mainGun_stageredFireRight)?1:0].transform.position - transform.forward),// The position
                                            transform.rotation);                                        // The rotation
						mainGun_stageredFireRight = true;
					}
					 break;
				}
				case 1:
				{
				nBullet= (GameObject)Instantiate(bulletTypes[bulletTypesIndex],(mainGunSpawners[1].transform.position - transform.forward),transform.rotation);
				nBullet= (GameObject)Instantiate(bulletTypes[bulletTypesIndex],(mainGunSpawners[0].transform.position- transform.forward),transform.rotation);
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
		// third gun here 
		
        */
        #endregion
	}

        private bool isFiring(int gunIndex)
        {
            return true;
            try
            {
                bool firing = false;
                FiringPattern fp = null;
                firingPatterns.TryGetValue(gunIndex, out fp);
                if (fp != null)
                {
                    //int guni = allGunSpawners.IndexOf(gun);
                    //if (guni == -1) return false;
                    //var temp = fp.gunSequence[guni];
                    int fire = fp.gunSequence[gunIndex][fp.sequenceIndex];
                    // quick and dirty code to loop sequenceIndex back to 0 if it's greater than count
                    //if (++fp.sequenceIndex > fp.gunSequence.Length) fp.sequenceIndex = 0;

                    firing = (fire == 1) ? true : false;
                    //if (firing) { fp.sequenceIndex++; }
                    return firing;
                }
            }
            catch { throw; }
            return false;
        }
	
	private void Testing()
	{
		if(Input.GetKeyDown(KeyCode.B))
		{
			if(ship_FireTypeIndex == 0)
			{
				ship_FireTypeIndex = 1;
			}
			else
			{
				ship_FireTypeIndex = 0;
			}
		}
		
		if(Input.GetKeyDown(KeyCode.N))
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
		
		
		if(Input.GetKeyDown(KeyCode.M))
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
