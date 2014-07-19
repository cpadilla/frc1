using UnityEngine; using System.Collections; 
public class Player : MonoBehaviour
{

	//Class Instance 
	public static Player Instance;
	//Variables
        public float m_speed = 10.00f;
        public float r_speed = 20.0f;
<<<<<<< HEAD
        public bool moving = false;
		
		
		private float v_Input = 0f;
		private float h_Input = 0f;
        // Use this for initialization
        void Awake()
        {
        	Instance = this;
=======
        public bool moving = false;
        public static Player instance;

        // Use this for initialization
        void Start()
        {
            instance = this;
>>>>>>> fc9eb9f9aca26343b2946629948b40a229549a94
        }

        // Update is called once per frame
        void Update()
<<<<<<< HEAD
        {
        	// Store the input from the player
            v_Input = Input.GetAxis("Vertical");
            h_Input = -Input.GetAxis("Horizontal");
            
            // check if there is vertical movement and bool it
            moving  = (v_Input > 0)? true:false;
            	
            // translate the input read from player this iteration 
            transform.Rotate(0,0, h_Input * Time.deltaTime * r_speed);
            transform.Translate(0, v_Input * Time.deltaTime * m_speed, 0);
=======
        {
            moving = (Mathf.Abs(Input.GetAxis("Vertical")) > 0);
            transform.Rotate(0,0,-Input.GetAxis("Horizontal") *Time.deltaTime* r_speed);
            transform.Translate(0, Input.GetAxis("Vertical")*Time.deltaTime*m_speed, 0);
>>>>>>> fc9eb9f9aca26343b2946629948b40a229549a94
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



