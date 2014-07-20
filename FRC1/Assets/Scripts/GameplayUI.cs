using UnityEngine;
using System.Collections;

public class GameplayUI : MonoBehaviour {

	public GUIText[] enemyCounters;
	public Texture[] weapons;

	public GUITexture weapon;
	public GUIText scoreText;

	public AudioSource playerDead;
	public AudioSource backGround;

	public float GameOverTimer;

	bool Lost=false;

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

		Lost=false;
	}

        void Update()
        {
            Score = Player.m_score;
			if(!Player.Instance.isAlive)
				LoseCondition();
			
			if(Lost)
				GameOverTimer+=Time.deltaTime;
        }

	public void UpdateEnemyCounter(int Index, int amount)
	{
		enemyCounters [Index].text = amount.ToString ();
	}

	public void UpdateWeaponIcon(int Index)
	{
		weapon.texture = weapons [Index];
	}

	public void LoseCondition()
	{
		if(!Lost)
		{
			backGround.Stop();
			playerDead.Play();
			Lost=true;

		}

		if(GameOverTimer>=6.0f)
		{
			Application.LoadLevel("FRC1");
			GameOverTimer=0;
			Player.m_score=0;
		}

	}

	public void OnGUI()
	{
		if(Lost)

		{	
			GUI.Label(new Rect(Screen.width/2,Screen.height/2,300,300),"GAME OVER");
			GUI.Label(new Rect(Screen.width/2,Screen.height/2,300,300),"\n"+Player.m_score.ToString());
		}
	}

}
