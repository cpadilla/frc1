﻿using UnityEngine;
using System.Collections;

public class MainCamera : MonoBehaviour {

    public GameObject ship;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
            transform.Rotate(0,0,Input.GetAxis("Horizontal") * Time.deltaTime * Player.m_speed);
            transform.Translate(0, Input.GetAxis("Vertical")*Time.deltaTime*Player.m_speed, 0);
	}
}
