using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnManager : MonoBehaviour {

    public List<GameObject> floatingObjects;

	// Use this for initialization
	void Start () {
            floatingObjects = new List<GameObject>();
            //Instantiate(GameObject.Find("Enemy"))
	}
	// Update is called once per frame
	void Update () {
            
	}
}
