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
            if(Input.GetMouseButtonDown(0))  // if get mouse down or touch count != 0 same call 
            {
                m_rRay = Camera.main.ScreenPointToRay(Input.mousePosition); // set the ray at that position to world space
                if(Physics.Raycast(m_rRay,out m_rcHit))  // if it hit something collect that data
                {
                    Application.LoadLevel(1);
                }
            }
        }

}
