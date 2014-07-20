using UnityEngine;
using System.Collections;

public class LoadingScreen : MonoBehaviour {

	// Use this for initialization
	void Start () {
		StartCoroutine (CR_WaitForInput ());
	}

	IEnumerator CR_WaitForInput()
	{
		while (!Input.GetMouseButton(0)) {
				yield return 0;
		}
		gameObject.SetActive (false);
	}

}
