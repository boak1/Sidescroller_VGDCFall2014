using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LeftWallCollision : MonoBehaviour {
	public Camera mainCam;


	public GameObject Platform3;
	public GameObject Platform2;
	public GameObject Platform1;
	public GameObject platformA;
	public GameObject platformS;
	public GameObject platformD;
	public GameObject platformF;

	Dictionary<string, GameObject> platOnScreen = new Dictionary<string, GameObject>();
	Dictionary<string, GameObject> allPlat = new Dictionary<string, GameObject>();


	public GameObject platformHolder;


	public treeBoss TBoss;
	// Use this for initialization
	void Start () {
		platformHolder = platformF;

		platOnScreen.Add (Platform1.name, Platform1);
		platOnScreen.Add (Platform2.name, Platform2);
		platOnScreen.Add (Platform3.name, Platform3);

		allPlat.Add (platformA.name, platformA);
		allPlat.Add (platformS.name, platformS);
		allPlat.Add (platformD.name, platformD);
		allPlat.Add (platformF.name, platformF);


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

		if (hitInfo.tag == "Platform"){
			//PlatformData platformData = hitInfo.GetComponent<PlatformData>();
			//platformData.lockPlatform();

			if (!TBoss.bossOnScreen){
				hitInfo.transform.position += new Vector3(mainCam.ScreenToWorldPoint(new Vector3(Screen.width*1.65f,0f,0f)).x, 0f, 0f);
			}
			else{
				hitInfo.transform.position += new Vector3(mainCam.ScreenToWorldPoint(new Vector3(Screen.width*1.45f,0f,0f)).x, 0f, 0f);
			}

			//IDEAS:
			//
			//GameObject temp = hitInfo.gameObject;
			// && hitInfo.name != "PlatformF(Clone)"){
			//if ("PlatformA" in hitInfo.name);
			//Instantiate(platformHolder, new Vector3(mainCam.ScreenToWorldPoint(new Vector3(Screen.width*1.65f,10f,0f)).x, 0f, 0f), Quaternion.identity);
			//platformHolder = hitInfo.gameObject;
			//Debug.Log(hitInfo.name);
			//Destroy(hitInfo.gameObject);
			//GameObject temp = hitInfo.gameObject;
			//GameObject platformHolder = GameObject.Find("PlatformF");
			//hitInfo.gameObject.SetActive(false);
			//PlatformF.SetActive(true);
			//testfind();
			//platformHolder.transform.position = new Vector3(mainCam.ScreenToWorldPoint(new Vector3(Screen.width*1.65f,10f,0f)).x, 0f, 0f);
			//platformHolder = hitInfo.gameObject;
		}

	}


    void OnTriggerEnter2D(Collider2D hitInfo){
        if (hitInfo.name == "Player")
        {
            Application.LoadLevel("deathscene"); //set as a level in unity build settings
        }
    }

	public void testfind(){
		//platformHolder = GameObject.Find ();
	}

}
