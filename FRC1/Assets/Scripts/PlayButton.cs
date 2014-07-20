using UnityEngine;
using System.Collections;

public class PlayButton : MonoBehaviour {
        
        private Ray m_rRay;
        public RaycastHit m_rcHit;

	// Use this for initialization
	void Start () {
	
	}
	
        void Update () 
        {
            if(Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Return))  // if get mouse down or touch count != 0 same call 
            {
                Vector3 v3 = Input.mousePosition;
                v3.z *= -1;
                m_rRay = Camera.main.ScreenPointToRay(v3); // set the ray at that position to world space
                Vector3 v4 = v3;
                v4.z += 400;
                Debug.DrawLine(v3, v4);
                if(Physics.Raycast(m_rRay,out m_rcHit)|| Input.GetKeyDown(KeyCode.Return))  // if it hit something collect that data
                {
                    Application.LoadLevel(1);
                }
            }
        }

}
