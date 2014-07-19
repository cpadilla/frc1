using UnityEngine;
using System.Collections;

public class Enemy : Unit {
	
	const int STATE_SEARCH = 0;
	const int STATE_ATTACK = 1;

	int m_state = 0;
	float m_search_distance = 15f;
	float m_rof = .5f; 				//rate of fire
	float m_range = 5f;

	static Transform target;

	void Awake()
	{
		m_health = 1;
		m_speed = 10;
		ChangeState (STATE_SEARCH);

		target = GameObject.Find ("Ship").transform;
	}

	float GetDistance()
	{
		return Mathf.Abs (Vector3.Distance (transform.position, target.position));
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
		switch (m_state) {
			case STATE_SEARCH:
				StartCoroutine("CR_SEARCH");
			break;

			case STATE_ATTACK:
				StartCoroutine("CR_ATTACK");
			break;
		}
	}

	void Attack()
	{
		//instantiate bullet code
	}
	
}
