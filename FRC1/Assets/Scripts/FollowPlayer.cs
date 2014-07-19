using UnityEngine;
using System.Collections;

public class FollowPlayer : MonoBehaviour {

        public GameObject player;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
            transform.rotation = player.transform.rotation;
            transform.position = player.transform.position;
            transform.Rotate(-90, 0, 0);
	}
}
