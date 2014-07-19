using UnityEngine;
using System.Collections;

public class PlayerShoot : MonoBehaviour {

	//Bullet to shoot
	public GameObject bullet;

	public Vector2 velocity;

	// Use this for initialization
	void Start () {
	

	}
	
	// Update is called once per frame
	void Update () {
	
		if(Input.GetButton("Fire1"))
		{

			Vector3 pos= this.transform.position;

			GameObject nBullet= (GameObject)Instantiate(bullet,pos,new Quaternion(0,0,0,0));


		}
	}

	//Input
}
