using UnityEngine;

using System.Collections;

public class PlayerShoot : MonoBehaviour {

	//
	//Bullet to shoot
	public GameObject bullet;

	//Velocity?
	public Vector2 velocity;
	
	//Fire rate
	public float m_fireRate=0.5f;
	float m_timer=0.0f;

	//GameObject player= GetComponent<Player>;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		m_timer += Time.deltaTime;

		if(Input.GetButton("Fire1") && m_timer >= m_fireRate )
		{


			Vector3 pos= this.transform.position;


			GameObject nBullet= (GameObject)Instantiate(bullet,(transform.position),transform.rotation);


			nBullet.transform.Translate(new Vector3(0,0,1));


			//nBullet.transform.Rotate(new Vector3(0,90,0));

			m_timer=0.0f;

		}
	}

	//Input
}
