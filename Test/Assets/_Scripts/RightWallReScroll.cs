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
			hitInfo.transform.position += new Vector3(166.4f, 0f, 0f);
		}
	}

	void OnTriggerEnter2D (Collider2D hitInfo){
		if (hitInfo.tag == "Platform") {
			//PlatformData platformData = hitInfo.GetComponent<PlatformData>();
			//platformData.unlockPlatform();
		}
	}
}
