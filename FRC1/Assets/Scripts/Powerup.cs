using UnityEngine;
using System.Collections;

public class Powerup : MonoBehaviour {

	public const int TYPE_LASER = 0;
	public const int TYPE_BURST = 1;
	public const int TYPE_RAPID = 2;

	public int type = 0;

	void Init(int Type) 
	{
		type = Type;
	}
}
