using UnityEngine;
using System.Collections;

public class Planet_Move : MonoBehaviour {


	public Vector3 m_rotVector;

	public float m_rotSpeed;

	float y,z;

	// Use this for initialization
	void Start () {

		 y= Random.Range(0,2000);
		y/=1000;

		z= Random.Range(0,2000);
		z/=1000;

		m_rotSpeed= Random.Range(0,20);

		m_rotVector= new Vector3(0,y,z);

		m_rotVector.Normalize();

		m_rotVector*=m_rotSpeed;

	}
	
	// Update is called once per frame
	void Update () {
	
		transform.Rotate(m_rotVector* Time.deltaTime);
	}
}
