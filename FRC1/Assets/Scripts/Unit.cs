using UnityEngine;
using System.Collections;

public class Unit : MonoBehaviour {

	public float m_speed;
	public float m_health;
	public Vector2 m_velocity;
	public float m_rotation;


	public virtual void Hit()
	{
		m_health-=1;
                if (m_health<=0)
                {
                    Destroy(gameObject);
                }

	}



}
