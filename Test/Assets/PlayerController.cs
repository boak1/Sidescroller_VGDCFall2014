using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public GameObject platform1;
	public GameObject platform2;
	public GameObject platform3;
	GameObject current_platform;
	// Use this for initialization
	void Start () {

	}
	//int LX = 0f,LY = 0f, nextLX = 10f, nextLY = 0f; //player Coordinates 
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.A))
		{
			current_platform = platform1;
		}
		if (Input.GetKeyDown (KeyCode.S)) 
		{
			current_platform = platform2;
		}
		if (Input.GetKeyDown (KeyCode.D)) 
		{
			current_platform = platform3;
		}
		PlatformData platformData = platform1.GetComponent<PlatformData>();
		transform.position = current_platform.transform.position + new Vector3(0f, platformData.offset(), 0f);
	}

	/*
	GameObject Platform(){
	
		int offset; //how much higher the player is than the platform
		int platx = -10f, platy = -10f; //lat and lon for platform

		//new variable for which prefab to use

		//something that describes if and how the platform is moving
		public Vector2 vec(){
			return new Vector2(platx, platy);
		}

	}
	*/
}