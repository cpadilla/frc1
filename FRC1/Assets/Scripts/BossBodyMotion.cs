using UnityEngine;
using System.Collections;

public class BossBodyMotion : MonoBehaviour {

        public float magnitude = 1.0f;
        public float frequency = .5f;
        public float angle = 30.0f;

        float xdegrees = 0.0f;
        float ydegrees = 0.0f;
        float zdegrees = 0.0f;

        static float rndseed;

	// Use this for initialization
	void Start () {
            //rndseed = Time.time + Random()
            System.Random rnd = new System.Random();
	
            float x = Mathf.Cos(rnd.Next() * frequency) / angle;
            float y = Mathf.Cos(rnd.Next() * frequency) / angle;
            float z = Mathf.Cos(rnd.Next() * frequency) / angle;
            transform.Rotate(x, y, z);
	}
	
	// Update is called once per frame
	void Update () {
            //float x = Time.time * xdegrees;
            //x = Mathf.Cos(x) * angle;
            float x = Mathf.Cos(Time.time * frequency) / angle;
            float y = Mathf.Cos(Time.time * frequency) / angle;
            float z = Mathf.Cos(Time.time * frequency) / angle;
            transform.Rotate(x, y, z);
	}
}
