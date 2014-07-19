using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WorldRenderer : MonoBehaviour {

        public GameObject player;
        public GameObject smallPlanet;
        public GameObject largePlanet;

        public List<GameObject> foregroundObjects;
        public List<GameObject> backgroundObjects;
        public float renderRadius = 100.0f;

        private float updateRate = 2.0f;
        private float minSpawnDistance = 30.0f;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
            // if it's time to respawn
            if (Time.time > Time.deltaTime * updateRate) {
                GameObject planet = (GameObject)Instantiate(smallPlanet, player.transform.position, transform.rotation);
                
                // get random position for object
                float rnd = Random.Range(-renderRadius, renderRadius);
                while (rnd == 0.0f) rnd = Random.Range(-renderRadius, renderRadius);
                float randomOffset = (Mathf.Abs(rnd) > minSpawnDistance) ? rnd : rnd + ((rnd > 0) ? 1 : -1) * minSpawnDistance;
                planet.transform.Translate(randomOffset, randomOffset, 0);
                backgroundObjects.Add(planet);

            }

        }
}
