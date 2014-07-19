using UnityEngine; using System.Collections; 
public class Player : MonoBehaviour
{

	//Class Instance 
	public static Player Instance;
	//Variables
        public float m_speed = 10.0f;
        public float r_speed = 50.0f;

        public int life = 1;
        public GameObject weapon;
        public bool moving = false;
		
		
        public float v_Input = 0f;
        public float h_Input = 0f;

        // Use this for initialization
        void Awake()
        {
        	Instance = this;
        }

        // Update is called once per frame
        void Update()
        {
        	// Store the input from the player
            v_Input = Input.GetAxis("Vertical");
            h_Input = -Input.GetAxis("Horizontal");
            
            // check if there is vertical movement and bool it
            moving  = (v_Input > 0)? true:false;
            	
            // translate the input read from player this iteration 
            transform.Rotate(0,0, h_Input * Time.deltaTime * r_speed);
            transform.Translate(0, v_Input * Time.deltaTime * m_speed, 0);
            
            if(v_Input == 0)
               	m_speed -= Time.deltaTime * .5f;
            else
            	m_speed = 10.0f;
            
            if(h_Input == 0)
            
            	r_speed -= Time.deltaTime;
             else
            	r_speed = 50.0f;
        }
	
		//transform.Rotate(Input.GetButton("Up"),90.0f);
		void OnTriggerEnter(Collider other)
		{
			print (other.name);
			switch (other.name) {
				case "EnemyShip":
					Destroy(other.gameObject);
				break;
				case "Laser":

				break;
				case "Powerup":
					Powerup collected = other.GetComponent<Powerup>();
					CollectedPowerup(collected.type);
					
				break;
			}
		}

		void CollectedPowerup(int type)
		{
			
		}
	}



