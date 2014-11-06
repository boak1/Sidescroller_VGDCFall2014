using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public GameObject platform1;
	public GameObject platform2;
	public GameObject platform3;

	// Use this for initialization
	void Start () {

	}
	//int LX = 0f,LY = 0f, nextLX = 10f, nextLY = 0f; //player Coordinates 
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.A))
		{
			//LX = nextLX; LY = nextLY;  //moves player to (Lx, LY)

			//Debug.Log ("a pressed - move player to x location");  //redraw character
			transform.position = platform1.transform.position + new Vector3(0f, 5f, 0f);
		}
		if (Input.GetKeyDown (KeyCode.S)) 
		{
			transform.position = platform2.transform.position + new Vector3(0f, 5f, 0f);
		}
		if (Input.GetKeyDown (KeyCode.D)) 
		{
			transform.position = platform3.transform.position + new Vector3(0f, 5f, 0f);
		}
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