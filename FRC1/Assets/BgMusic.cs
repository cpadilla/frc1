using UnityEngine;
using System.Collections;

public class BgMusic : MonoBehaviour {


	public AudioSource bg_Music;
	public Texture2D  button;

	// Use this for initialization
	void Start () {
		bg_Music.Play();
	}
	
	// Update is called once per frame
	void Update () {
	

	}

	void OnGUI()
	{
		if(GUI.Button(new Rect(Screen.width/2,Screen.height/2,300,150),button))
		 {
			bg_Music.Stop();
			Application.LoadLevel("FRC1");
		}

	}
}
