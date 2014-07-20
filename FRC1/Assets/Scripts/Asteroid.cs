using UnityEngine;
using System.Collections;

public class Asteroid : Unit {

	public GameObject[] explosion;
	public GameObject player;
	public Vector3 pos;

	//
	// Use this for initialization
	void Start () {
	
		m_health=3;

		pos=this.gameObject.transform.position;
	}
	
	// Update is called once per frame
	void Update () {


		//transform.Rotate(new Vector3(0,1,1),Space.World);
		transform.Translate(m_velocity*Time.deltaTime);

        
                
				//Destroy(gameObject);
            }
        
        
    
    
    void OnTriggerEnter(Collider collision)
	{
		print ("Im work");
		//if(collision.gameObject.tag=="Proj")
		//	Destroy(this.gameObject);
		
	}

	override public void  Hit()
	
	{
		m_health--;
		if(m_health<=0)
			
		{	
			for (int i = 0; i < explosion.Length; i++) {
				{	
					GameObject item= (GameObject)Instantiate(explosion[i],gameObject.transform.position,
					                                         Quaternion.identity);

					//item.rigidbody.AddForce(0,0,0);
				}
				
				
				Destroy(gameObject);
			}
		}

	}

	void OnDestroy()
	{

	}

}
