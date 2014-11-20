using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	//asks the programmer to define four variables representing the four different platforms
	//define them by dragging and dropping game objects into the appropriate variable components attatched to the player controller script
	//which is attached to the player in the unity inspector
	public GameObject platformA;
	public GameObject platformS;
	public GameObject platformD;
	public GameObject platformF;
	GameObject current_platform;
	// Use this for initialization
	void Start () {
		current_platform = platformS;
	}
	//int LX = 0f,LY = 0f, nextLX = 10f, nextLY = 0f; //player Coordinates 
	// Update is called once per frame
	void Update () {

		//platforms
		if (Input.GetKeyDown(KeyCode.A))
		{
			current_platform = platformA;
		}
		if (Input.GetKeyDown (KeyCode.S)) 
		{
			current_platform = platformS;
		}
		if (Input.GetKeyDown (KeyCode.D)) 
		{
			current_platform = platformD;
		}
		if (Input.GetKeyDown (KeyCode.F)) 
		{
			current_platform = platformF;
		}


		//shooting
		if (Input.GetKeyDown (KeyCode.J)) 
		{
		}
		if (Input.GetKeyDown (KeyCode.K)) 
		{
		}
		if (Input.GetKeyDown (KeyCode.L)) 
		{
		}

		PlatformData platformData = current_platform.GetComponent<PlatformData>();
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