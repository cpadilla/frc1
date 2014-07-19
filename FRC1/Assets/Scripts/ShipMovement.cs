using UnityEngine; using System.Collections; 
public class ShipMovement : MonoBehaviour
{
	//Variables

        // Use this for initialization
        void Start()
        {
            Player.Initialize();
        }

        // Update is called once per frame
        void Update()
        {
            transform.Rotate(0,0,Input.GetAxis("Horizontal") * Time.deltaTime * Player.m_speed);
            transform.Translate(0, Input.GetAxis("Vertical")*Time.deltaTime*Player.m_speed, 0);
        }

		//transform.Rotate(Input.GetButton("Up"),90.0f);

	}



