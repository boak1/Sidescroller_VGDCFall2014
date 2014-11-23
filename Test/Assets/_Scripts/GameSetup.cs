using UnityEngine;
using System.Collections;

public class GameSetup : MonoBehaviour {
	public Camera mainCam;

	public BoxCollider2D leftWall;
	public BoxCollider2D rightWall;

	public GameObject player;

	public GameObject platformA;
	public GameObject platformS;
	public GameObject platformD;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		leftWall.size = new Vector2 (1f, mainCam.ScreenToWorldPoint(new Vector3(0f, Screen.height*2f, 0f)).y);
		leftWall.center = new Vector2(mainCam.ScreenToWorldPoint(new Vector3(0f, 0f, 0f)).x - 0.5f, 0f);

		rightWall.size = new Vector2 (1f, mainCam.ScreenToWorldPoint (new Vector3 (0f, Screen.height * 2f, 0f)).y);
		rightWall.center = new Vector2 (mainCam.ScreenToWorldPoint (new Vector3 (Screen.width, 0f, 0f)).x + 0.5f, 0f);
	}
}
