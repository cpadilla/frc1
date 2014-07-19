using UnityEngine;
using System.Collections;

public class Powerup : MonoBehaviour {

	const int TYPE_LASER = 0;
	const int TYPE_BURST = 1;
	const int TYPE_RAPID = 2;

	public int type = 0;

	void Init(int Type) 
	{
		type = Type;
	}
}
