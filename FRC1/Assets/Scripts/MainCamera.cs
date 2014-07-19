using UnityEngine;
using System.Collections;

public class MainCamera : MonoBehaviour {

    public GameObject ship;

    Player player;

	// Use this for initialization
	void Start () {
            player = GameObject.Find("Ship").GetComponent<Player>();
	}
	
	// Update is called once per frame
	void Update () {
            transform.Rotate(0,0,Input.GetAxis("Horizontal") * Time.deltaTime * player.m_speed);
            transform.Translate(0, Input.GetAxis("Vertical")*Time.deltaTime*player.m_speed, 0);
	}
}
