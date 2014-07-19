using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WorldRenderer : MonoBehaviour {

        public List<GameObject> foregroundObjects;
        public List<GameObject> backgroundObjects;

        private float updateRate = 2.0f;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
            // if it's time to respawn
            if (Time.time > Time.deltaTime * updateRate) {


            }

        }
}
