using UnityEngine; using System.Collections; 
public class Player : Unit
{

        //Class Instance 
        public static Player Instance;
        public static GameObject MainPlayer;
        public GameObject weapon;

        public int Score;
	public int scoreOT=10; //Score over time
	public float scoreTimer=0.0f;
	//oe
	public static int m_score=0;
	public GUIStyle scoreStyle;
	public Rect m_scoreRect;

        public float r_speed = 1000.0f;
         
        public float m_drag = -1.0f;        public float v_Input = 0f;        public float h_Input = 0f;            public bool moving = false;


        // Use this for initialization
    void Awake()
    {
    	Instance = this;
    }

        // Use this for initialization
        
	void Start()
	{
		//Velocity
	

		//Variables
		m_speed = 1000.0f;

		//Health
		m_health = 3.0f;

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

		scoreTimer+=Time.deltaTime;

		if(scoreTimer >=1.0f)
		{
			m_score+=scoreOT;
			scoreTimer=0;
		}


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
		Unit unit= other.GetComponent<Unit>();

		print (other.tag);
		switch (other.tag) {
			case "Enemy":
				//Destroy(other.gameObject);
			Hit();
			unit.Hit();
			break;
			case "Laser":

			//if(other.gameObject.tag!="PlayerProj")
			//	Hit();

			break;
			case "Powerup":
				Powerup collected = other.GetComponent<Powerup>();
				CollectedPowerup(collected.type);
				
			break;
		case "Floating":
			//Destroy(other.gameObject);
			Hit();

			unit.Hit();
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

		//GUI.Label(m_scoreRect,m_score.ToString(),scoreStyle);

		if(m_health<=0)
			GUI.Label(new Rect(0,0,30,30),"YOU LOSE",scoreStyle);

		GUI.Label(new Rect(0,0,30,30),m_health.ToString(),scoreStyle);

	}

    public override void Hit()
    {
        m_health-=1;
        if (m_health<=0)
        {
            //Destroy(gameObject);
        }
    }
}




