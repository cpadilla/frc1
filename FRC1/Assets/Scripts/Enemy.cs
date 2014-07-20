using UnityEngine;
using System.Collections;

public class Enemy : Unit {

	public GameObject prefabBullet;
	private GameObject player;

	const int STATE_SEARCH = 0;
	const int STATE_ATTACK = 1;
	const int STATE_DESTROYED = 2;

	public int m_typeIndex = 0; 
	int m_state = 0;

	public float m_search_distance = 150f;
	public float m_rof = .5f; 				//rate of fire
	public float m_range = 5f;
	public float rotate_rate = 20;
	public float rangeFromPlayer = 10; 

	public GameObject soundExplosionDummy;

	bool isReadyToFire = true;

	//Score to player
	public int m_score;

	public static Transform target;
	public ParticleSystem enemyDead;
	void Awake()
	{
		m_health = 1;
		m_speed = 10;

		gameObject.name = "EnemyShip";
        player = Player.Instance.gameObject;
	}
	void Start()
	{
		if(player == null)
			player = GameObject.Find ("Player");
		target = player.transform;
		ChangeState (STATE_SEARCH);

		m_score=100;
	}
	
	void OnTriggerEnter(Collider other)
	{
		Unit player= (Unit)other.GetComponent<Unit>();
	
		if(other.tag == "PlayerBullet")
		{
		    //throw new System.Exception();
		}
	}

	float GetDistance()
	{
		target = player.transform;
	    float val = Mathf.Abs (Vector3.Distance (transform.position, target.position)); 

		return val;
	}

	IEnumerator CR_SEARCH()
	{
		while (GetDistance() >= m_search_distance)
		{
			yield return 0;
		}
		ChangeState (STATE_ATTACK);
	}

	IEnumerator CR_FireCooldown()
	{
		yield return new WaitForSeconds (m_rof);
		isReadyToFire = true;
	}

	IEnumerator CR_ATTACK()
	{
		float distance;
		while (m_health > 0 ) 
		{
			distance = GetDistance();
			if(distance <= m_search_distance)	//if within sight distance
			{
				if(isReadyToFire && distance <= m_range) 		//if within attack range
				{
					Attack();					//attack
				}

				if(distance > rangeFromPlayer)
					MoveToTarget();				//move closer
			}
			else 		//outside of sight range, go to Search State
				break;

			yield return 0;
		}
		ChangeState (STATE_SEARCH);
	}
	
	public void ChangeState(int NEW_STATE)
	{
		m_state = NEW_STATE;
	    print("New State " + m_state.ToString());
	    switch (m_state)
	    {
	        case STATE_SEARCH:
	            StartCoroutine("CR_SEARCH");
	            break;

	        case STATE_ATTACK:
	            StartCoroutine("CR_ATTACK");
	            break;
	        case STATE_DESTROYED:
	            StopAllCoroutines();
	            break;
	    }
	}

	void OnGUI()
	{
		Debug.DrawLine (transform.position, transform.position + transform.forward * m_search_distance);
	}

	void MoveToTarget()
	{
		Vector3 targetDir = target.position - transform.position;
		float step = rotate_rate * Time.deltaTime;
		Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, step, 0.0F);
		transform.rotation = Quaternion.LookRotation(new Vector3(newDir.x, newDir.y, 0));

		transform.position += transform.forward * m_speed * Time.deltaTime;

		transform.position = new Vector3(transform.position.x, transform.position.y, 0);
		//transform.postion = Vector3.MoveTowards(transform.position, target.position, Time.deltaTime);
	}

	void Attack()
	{
		isReadyToFire = false;
		StartCoroutine (CR_FireCooldown ());

		//instantiate bullet code
		GameObject bullet = (GameObject)Instantiate (prefabBullet, transform.position + transform.forward * 5, transform.rotation);
		//bullet.GetComponent<Laser>().
	}
	private bool isQuitting = false; void OnApplicationQuit() { isQuitting = true; }

	override public void Hit()
	{
	
		base.Hit();

	}
	void OnDestroy()
	{
		//EnemySpawner.getInstance ().RemoveEnemy (m_typeIndex, gameObject);
		//Player play= player.GetComponent<Player>();
		if (!isQuitting) {
						Instantiate (enemyDead, this.transform.position, this.transform.rotation);
						enemyDead.Play ();
				}
		Instantiate(soundExplosionDummy,this.transform.position,transform.rotation);
		Player.m_score+=m_score;
	}
}
