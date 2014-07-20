using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WorldRenderer : MonoBehaviour {

        public GameObject player;

        public GameObject smallPlanet;
        public GameObject largePlanet;
        public GameObject enemy;

        public List<GameObject> foregroundObjects;
        public List<GameObject> backgroundObjects;
        public List<GameObject> prefabs;

        // World Renderer
        public float renderRadius = 400.0f;
        private float minSpawnDistance = 3.0f;
        private int maxObjectCount = 30;
        private int initObjectCount = 3;

        // spawn timer
        private float spawnTimer = 0.0f;
        private float spawnRate = 100.0f;
        private float spawnInterval = 10.0f;

        // Prefab Offsets
        private float largePlanetOffset = 100.0f;

        private static WorldRenderer _instance;
        private static bool _set = false;

        public static WorldRenderer Instance
        {
            get
            {
                return _instance;
            }
            set
            {
                if (!_set)
                {
                    _instance = value;
                    _set = true;
                }
            }
        }

	// Use this for initialization
	void Start () {
            //for (int i = 0; i < initObjectCount; i++) SpawnObjects();
            Instance = this;
	}
	
	// Update is called once per frame
	void Update () {
            spawnTimer += spawnRate;
            // if it's time to respawn
            SpawnObjects();
            DelteFarObjects();
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
            if (spawnTimer > spawnInterval && backgroundObjects.Count <= maxObjectCount)
            {
                GameObject obj = getNextSpawnObject();
                if (obj.GetComponent("Enemy") != null) foregroundObjects.Add(obj);
                else backgroundObjects.Add(obj);
                spawnTimer = 0;
            }
        }

        void DelteFarObjects()
        {
            for (int i = backgroundObjects.Count - 1; i >= 0; i--)
            {
                GameObject obj = backgroundObjects[i];
                if (Vector3.Distance(player.transform.position, obj.transform.position) > renderRadius)
                {
                    backgroundObjects.RemoveAt(i);
                    Destroy( obj );
                }
            }
        }

        GameObject getNextSpawnObject()
        {
			
            //if(obj)
            GameObject obj = null;
            while (obj == null)
            {
                try
                {
                    obj = (GameObject)Instantiate(prefabs[Random.Range(0, prefabs.Count)], player.transform.position, transform.rotation);
                }
                catch { }
            }
            // get random position for object
            float xrandomOffset = getRandomOffset(renderRadius, minSpawnDistance);
            float yrandomOffset = getRandomOffset(renderRadius, minSpawnDistance);
            float zrandomOffset = Mathf.Abs(getRandomOffset(renderRadius, minSpawnDistance));
            obj.transform.Translate(xrandomOffset, yrandomOffset, zrandomOffset);
            obj.transform.parent = GameObject.Find("BackgroundContainer").transform;

            if (obj.tag == "LargePlanet")
            {
                obj.transform.Translate(0, 0, largePlanetOffset);
            }

            return obj;
        }

        //public bool Delete(GameObject obj)
        //{
        //    bool del = false;
        //    del = foregroundObjects.Remove(obj);
        //    Destroy(obj);
        //    return del;
        //}
}
