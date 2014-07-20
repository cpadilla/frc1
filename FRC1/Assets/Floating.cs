using UnityEngine;
using System.Collections;

public class Floating : MonoBehaviour {

	public Vector3 m_velocity;
	public float m_speed;

	// Use this for initialization
	void Start () {
	
		float x=(float) Random.Range(-2000,2000) / 1000.0f;
		float y= (float) Random.Range(-2000,2000)/1000.0f;

	m_velocity= new Vector3(x,y,0);
	m_speed= Random.Range(-3,3);

		if(m_speed==0)
			m_speed++;

		m_velocity*=m_speed;

	}
	
	// Update is called once per frame
	void Update () {
		transform.position+=m_velocity*Time.deltaTime;
	}

	void OnTriggerEnter(Collider trig)
	{
		print ("Colliding with piece");
		Unit unit= trig.GetComponent<Unit>();

		if(unit)
			unit.Hit();

		if(trig.gameObject.tag == "Player")
			Destroy (gameObject);
	}
}
