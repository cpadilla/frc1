using UnityEngine; using System.Collections; 
public class Player : MonoBehaviour
{
	//Variables
        public float m_speed = 10.00f;
        public float r_speed = 20.0f;
        public bool moving = false;

        // Use this for initialization
        void Start()
        {
        }

        // Update is called once per frame
        void Update()
        {
            moving = (Mathf.Abs(Input.GetAxis("Vertical")) > 0);
            transform.Rotate(0,0,-Input.GetAxis("Horizontal") *Time.deltaTime* r_speed);
            transform.Translate(0, Input.GetAxis("Vertical")*Time.deltaTime*m_speed, 0);
        }

		//transform.Rotate(Input.GetButton("Up"),90.0f);

	}



