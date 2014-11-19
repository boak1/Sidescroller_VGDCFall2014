using UnityEngine;
using System.Collections;

public class LeftWallCollision : MonoBehaviour {
	public Camera mainCam;
	public GameObject PlatformF;
	//public GameObject platformHolder;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerExit2D (Collider2D hitInfo){
		/*
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
		*/


		if (hitInfo.name == "Player") 
		{
			Application.LoadLevel ("deathscene"); //set as a level in unity build settings
		}
		else if (hitInfo.tag == "Platform"){// && hitInfo.name != "PlatformF(Clone)"){
			hitInfo.transform.position += new Vector3(mainCam.ScreenToWorldPoint(new Vector3(Screen.width*1.65f,0f,0f)).x, 0f, 0f);

			//GameObject temp = 
			//GameObject platformHolder = GameObject.Find("PlatformF");
			//hitInfo.gameObject.SetActive(false);
			//PlatformF.SetActive(true);
			//testfind();
			//platformHolder.transform.position = new Vector3(mainCam.ScreenToWorldPoint(new Vector3(Screen.width*1.65f,10f,0f)).x, 0f, 0f);
			//Instantiate(PlatformF, new Vector3(mainCam.ScreenToWorldPoint(new Vector3(Screen.width*1.65f,10f,0f)).x, 0f, 0f), Quaternion.identity);
			//platformHolder = hitInfo.gameObject;
		}

	}


	public void testfind(){
		//platformHolder = GameObject.Find ();
	}

}
