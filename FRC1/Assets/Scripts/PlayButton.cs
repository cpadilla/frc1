using UnityEngine;
using System.Collections;

public class PlayButton : MonoBehaviour {
        
        private Ray m_rRay;
        private RaycastHit m_rcHit;
		public  Camera  thisCamera;
	// Use this for initialization
	void Start () {
	
	}
	
        void Update () 
        {
        	if(Input.GetKeyDown(KeyCode.Return))
        	{
        		Application.LoadLevel(1);
        	}
        }
       

}
