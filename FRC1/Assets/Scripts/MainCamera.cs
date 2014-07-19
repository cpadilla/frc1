using UnityEngine;
using System.Collections;

public class MainCamera : MonoBehaviour {

    public GameObject ship;

    Player player;

	// Use this for initialization
	void Start () {
            player = ship.GetComponent<Player>();
	}
	
	// Update is called once per frame
	void Update () {
            transform.Rotate(0, 0, player.h_Input * Time.deltaTime* player.r_speed);
            transform.Translate(0, player.v_Input * Time.deltaTime *player.m_speed, 0);
	}
}
