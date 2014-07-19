using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnManager : MonoBehaviour {

    public List<GameObject> spawners;

	public float spawnInterval = .5f;
	// Use this for initialization
	void Start () {
		StartCoroutine (CR_Spawn ());
	}

	IEnumerator CR_Spawn()
	{
		while (true) {
			Instantiate (spawners [0]);
			yield return new WaitForSeconds (spawnInterval);
		}
	}
	// Update is called once per frame
	void Update () {
	}
}
