using UnityEngine;
using System.Collections;

public class Laser : MonoBehaviour {


	public Vector2 velocity;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

		//this.transform.position += this.transform.forward*Time.deltaTime;

		transform.position += transform.up * Time.deltaTime*100;
	}
}
