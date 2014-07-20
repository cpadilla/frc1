using UnityEngine;
using System.Collections;

public class Powerup : MonoBehaviour {

	public const int TYPE_LASER = 0;
	public const int TYPE_BULLET = 1;
	public const int TYPE_ARMOR = 2;
	public const int TYPE_ARMORTWO = 3;

	public int type = 0;

	static Transform player;
	void Awake()
	{
		if (player == null)
			player = GameObject.FindGameObjectWithTag ("Player").transform;

		StartCoroutine (CR_DistanceCheck ());
		transform.parent = GameObject.Find ("WorldRenderer").transform;
	}
	
	float GetDistance()
	{
		float val = Mathf.Abs (Vector3.Distance (transform.position, player.position)); 
		return val;
	}

	IEnumerator CR_DistanceCheck()
	{
		while (true) {
			if(GetDistance() > 150)
				Destroy(gameObject);
			yield return new WaitForSeconds(1); //check every second	
		}
	}

	public void OnCollected()
	{
		Destroy (gameObject);
	}

	void OnDestroy()
	{
		StopAllCoroutines ();
	}
}
