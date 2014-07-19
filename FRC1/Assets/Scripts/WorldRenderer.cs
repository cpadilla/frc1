using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WorldRenderer : MonoBehaviour {

        public GameObject player;

        public GameObject smallPlanet;
        public GameObject largePlanet;

        public List<GameObject> foregroundObjects;
        public List<GameObject> backgroundObjects;
        public List<GameObject> prefabs;

        public float renderRadius = 400.0f;
        private float minSpawnDistance = 3.0f;
        private int maxObjectCount = 30;
        private int initObjectCount = 3;

        private float spawnTimer = 0.0f;
        private float spawnRate = 100.0f;
        private float spawnInterval = 100.0f;

        void Awake()
        {
            prefabs.Add(smallPlanet);
            prefabs.Add(largePlanet);
            for (int i = 0; i < initObjectCount; i++) SpawnObjects();
        }

	// Use this for initialization
	void Start () {
            for (int i = 0; i < initObjectCount; i++) SpawnObjects();
	}
	
	// Update is called once per frame
	void Update () {
            spawnTimer += Time.deltaTime * spawnRate;
            // if it's time to respawn
            SpawnObjects();
        }
        
        // Gets an appropriate offset for the world object
        float getRandomOffset(float renderRadius, float minSpawnDistance)
        {
            float rnd = Random.Range(-renderRadius, renderRadius);
            while (rnd == 0.0f) rnd = Random.Range(-renderRadius, renderRadius);
            return  (Mathf.Abs(rnd) > minSpawnDistance) ? rnd : rnd + ((rnd > 0) ? 1 : -1) * minSpawnDistance;
        }

        void SpawnObjects()
        {
            // if it's time to spawn objects and there is a need for objects
            if (spawnTimer > Time.deltaTime * spawnInterval && backgroundObjects.Count <= maxObjectCount)
            {
                GameObject obj = getNextSpawnObject();
                backgroundObjects.Add(obj);
            }
        }

        GameObject getNextSpawnObject()
        {
            GameObject obj = (GameObject)Instantiate(prefabs[Random.Range(0, prefabs.Count)], player.transform.position, transform.rotation);
            // get random position for object
            float xrandomOffset = getRandomOffset(renderRadius, minSpawnDistance);
            float yrandomOffset = getRandomOffset(renderRadius, minSpawnDistance);
            float zrandomOffset = Mathf.Abs(getRandomOffset(renderRadius, minSpawnDistance));
            obj.transform.Translate(xrandomOffset, yrandomOffset, zrandomOffset);
            return obj;
        }
}
