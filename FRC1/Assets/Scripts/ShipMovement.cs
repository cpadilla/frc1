using UnityEngine;
using System.Collections;

public class ShipMovement : MonoBehaviour
{
	//Variables
	public float m_speed=1.0f;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
		transform.Translate(Input.GetAxis("Horizontal")*Time.deltaTime*m_speed, Input.GetAxis("Vertical")*Time.deltaTime*m_speed, 0);
    }


}
