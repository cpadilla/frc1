using UnityEngine;
using System.Collections;

public class GameplayUI : MonoBehaviour {

	public GUIText[] enemyCounters;
	public GUIText score;

	private static GameplayUI instance;

	public static GameplayUI getInstance()
	{
		if (instance == null)
			instance = new GameplayUI ();

		return instance;
	}

	public void UpdateScore(int amount)
	{
		score.text = amount.ToString ();
	}
	public void UpdateEnemyCounter(int Index, int amount)
	{
		enemyCounters [Index].text = amount.ToString ();
	}

}
