using UnityEngine;
using System.Collections;

public class RightWallReScroll : MonoBehaviour {
	public Camera mainCam;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerExit2D (Collider2D hitInfo){
		if (hitInfo.name == "BG") 
		{
			hitInfo.transform.position += new Vector3(mainCam.ScreenToWorldPoint(new Vector3(Screen.width*2f,0f,0f)).x, 0f, 0f);
		}
	}
}
