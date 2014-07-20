using UnityEngine; using System.Collections; 
public class Player : Unit
{

	//Class Instance 
	public static Player Instance;
        public static GameObject MainPlayer;

        public int Score;
        public float r_speed = 1000.0f;
            public GameObject weapon;
        public bool moving = false;
		
        public float v_Input = 0f;
        public float h_Input = 0f;


	//oe
	public static int m_score=0;

	public GUIStyle scoreStyle;

	public Rect m_scoreRect;

        // Use this for initialization
    void Awake()
    {
    	Instance = this;
    }

        // Use this for initialization
        
	void Start()
	{

		//Variables
		m_speed = 1000.0f;

		//Health
		m_health = 1;

        string text= m_score.ToString();
		
		int widthTextOffset= text.Length;
		
		
		m_scoreRect.x=Screen.width/4;
		m_scoreRect.y=Screen.height*3/4;
		
		m_scoreRect.width = m_scoreRect.x+100;
		m_scoreRect.height= m_scoreRect.y +20;

	}
	// Update is called once per frame
	void Update()
	{
            Score = m_score;
		// Store the input from the player
	    v_Input = Input.GetAxis("Vertical");
	    h_Input = -Input.GetAxis("Horizontal");
	    
	    // check if there is vertical movement and bool it
	    moving  = (v_Input > 0)? true:false;
	    	
	    // translate the input read from player this iteration 
	    transform.Rotate(0,0, h_Input * Time.deltaTime * r_speed);
	    transform.Translate(0, v_Input * Time.deltaTime * m_speed, 0);
	    
	    if(v_Input == 0)
	       	m_speed -= Time.deltaTime * .5f;
	    else
	    	m_speed = 10.0f;
	    
	    if(h_Input == 0)
	    
	    	r_speed -= Time.deltaTime;
	     else
	    	r_speed = 50.0f;
	}

	//transform.Rotate(Input.GetButton("Up"),90.0f);
	void OnTriggerEnter(Collider other)
	{
		print (other.name);
		switch (other.name) {
			case "EnemyShip":
				//Destroy(other.gameObject);
			break;
			case "Laser":

			break;
			case "Powerup":
				Powerup collected = other.GetComponent<Powerup>();
				CollectedPowerup(collected.type);
				
			break;
		}
	}

	void CollectedPowerup(int type)
	{
		switch (type) {
			case Powerup.TYPE_LASER:

			break;
			case Powerup.TYPE_BURST:
			
			break;
			case Powerup.TYPE_RAPID:
			
			break;
		}

	}

	void OnGUI()
	{
		//width,height,Screen.width-width,height+10

		GUI.Label(m_scoreRect,m_score.ToString(),scoreStyle);

		if(m_health<=0)
			GUI.Label(new Rect(0,0,30,30),"YOU LOSE",scoreStyle);
	}

    public override void Hit()
    {
        m_health-=1;
        if (m_health<=0)
        {
            //Destroy(gameObject);
            Player.m_score = -99999;
        }
    }
}




