using UnityEngine; using System.Collections; 
public class Player : MonoBehaviour
{

	//Class Instance 
	public static Player Instance;
	//Variables
        public float m_speed = 10.00f;
        public float r_speed = 20.0f;

        public bool moving = false;
		
		
		private float v_Input = 0f;
		private float h_Input = 0f;
        // Use this for initialization
        void Awake()
        {
        	Instance = this;
       }
        // Use this for initialization
        

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

        }

		//transform.Rotate(Input.GetButton("Up"),90.0f);
		void OnTriggerEnter(Collider other)
		{
		print (other.name);
			if (other.name == "EnemyShip") {
				Destroy(other.gameObject);
			}
		}
	}



