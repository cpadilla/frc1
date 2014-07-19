using UnityEngine;
using System.Collections;

public class Enemy : Unit {
	
	const int STATE_SEARCH = 0;
	const int STATE_ATTACK = 1;

	int m_state = 0;
	public float m_search_distance = 15f;
	public float m_rof = .5f; 				//rate of fire
	public float m_range = 5f;

	public float rotate_rate = 20;

	public static Transform target;

	void Awake()
	{
		m_health = 1;
		m_speed = 10;

		target = GameObject.Find ("Ship").transform;
		ChangeState (STATE_SEARCH);
	}

	float GetDistance()
	{
		float val = Mathf.Abs (Vector3.Distance (transform.position, target.position)); 
		print (val);
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

	IEnumerator CR_ATTACK()
	{
		float distance;
		while (m_health > 0 ) 
		{
			distance = GetDistance();
			if(distance <= m_search_distance)	//if within sight distance
			{
				if(distance <= m_range) 		//if within attack range
				{
					Attack();					//attack
					yield return new WaitForSeconds(m_rof);
				}
				else
					MoveToTarget();				//move closer
			}
			else 		//outside of sight range, go to Search State
				break;

			yield return 0;
		}

		
		ChangeState (STATE_SEARCH);
	}

	void ChangeState(int NEW_STATE)
	{
		m_state = NEW_STATE;
		print ("New State " + m_state.ToString ());
		switch (m_state) {
			case STATE_SEARCH:
				StartCoroutine("CR_SEARCH");
			break;

			case STATE_ATTACK:
				StartCoroutine("CR_ATTACK");
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
		//transform.postion = Vector3.MoveTowards(transform.position, target.position, Time.deltaTime);
	}

	void Attack()
	{
		//instantiate bullet code
	}
	
}
