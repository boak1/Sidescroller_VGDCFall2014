using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
	
	}
	int LX = 0f,LY = 0f, nextLX = 10f, nextLY = 0f; //player Coordinates 
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.A))
		{
			LX = nextLX; LY = nextLY;  //moves player to (Lx, LY)

			Debug.Log ("a pressed - move player to x location");  //redraw character
			//gameObject.position(LX,LY, 0f);
		}
	}
}
