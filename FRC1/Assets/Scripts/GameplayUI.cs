using UnityEngine;
using System.Collections;

public class GameplayUI : MonoBehaviour {

	public GUIText[] enemyCounters;
	public GUIText scoreText;
        public int playerScore;
        public int Score
        {
            get
            {
                return int.Parse(scoreText.ToString());
            }
            set
            {
                try
                {
                    scoreText.text = value.ToString();
                }
                catch { }
            }
        }

	private static GameplayUI instance;

	public static GameplayUI getInstance()
	{
		return instance;
	}

	void Awake()
	{
		if (instance == null)
			instance = this;
		else
			Destroy(gameObject);

	}

        void Update()
        {
            Score = Player.m_score;
        }

	public void UpdateEnemyCounter(int Index, int amount)
	{
		enemyCounters [Index].text = amount.ToString ();
	}

}
