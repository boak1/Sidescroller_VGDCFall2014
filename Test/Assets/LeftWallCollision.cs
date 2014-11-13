using UnityEngine;
using System.Collections;

public class LeftWallCollision : MonoBehaviour {
	public Camera mainCam;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerExit2D (Collider2D hitInfo){
		if (hitInfo.name == "PlatformA") 
		{
			hitInfo.transform.position += new Vector3(mainCam.ScreenToWorldPoint(new Vector3(Screen.width*1.65f,0f,0f)).x, 0f, 0f);
		}
		if (hitInfo.name == "PlatformS") 
		{
			hitInfo.transform.position += new Vector3(mainCam.ScreenToWorldPoint(new Vector3(Screen.width*1.65f,0f,0f)).x, 0f, 0f);
		}
		if (hitInfo.name == "PlatformD") 
		{
			hitInfo.transform.position += new Vector3(mainCam.ScreenToWorldPoint(new Vector3(Screen.width*1.65f,0f,0f)).x, 0f, 0f);
		}
	}
}
