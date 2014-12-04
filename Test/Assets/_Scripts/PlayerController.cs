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

	public treeBoss TBoss;

	//Player lasers to shoot
	public GameObject redLaser;
	public GameObject greenLaser;
	public GameObject blueLaser;
	private GameObject current_laser;
	private float shooting_cooldown = .1f;

	//set starting health to 3
	public static int hp = 3;  //static so other scripts can see it. call with Test.hp

	//audio-related vars; will eventually have vars for teleport, player shoot, and player damaged sounds
	public AudioClip sfxTeleport = new AudioClip();
	private AudioSource audioSource = new AudioSource();	//only one Audio Source needed apparently

	// Use this for initialization
	void Start () {
		current_platform = platformS;
		hp = 3; //on restarting after a game over hp becomes 3 again
		audioSource = GetComponent<AudioSource>();
		//current_laser = new GameObject[10];
	}
	//int LX = 0f,LY = 0f, nextLX = 10f, nextLY = 0f; //player Coordinates 
	// Update is called once per frame
	void Update () {


				
		//platforms
		if (Input.GetKeyDown(KeyCode.A))
		{
			current_platform = platformA;
			audioSource.PlayOneShot(sfxTeleport, .8f);
		}
		if (Input.GetKeyDown (KeyCode.S)) 
		{
			current_platform = platformS;
			audioSource.PlayOneShot(sfxTeleport, .8f);
		}
		if (Input.GetKeyDown (KeyCode.D)) 
		{
			current_platform = platformD;
			audioSource.PlayOneShot(sfxTeleport, .8f);
		}
		if (Input.GetKeyDown (KeyCode.F)) 
		{
			current_platform = platformF;
			audioSource.PlayOneShot(sfxTeleport, .8f);
		}


		//shooting
		shooting_cooldown -= Time.deltaTime;

		if (Input.GetKeyDown (KeyCode.J) && shooting_cooldown <= 0) 
		{
			current_laser = (GameObject)Instantiate(redLaser, transform.position+new Vector3(75, 0, 0), Quaternion.identity);
			Invoke ("DestroyLaser", .05f);
			TBoss.shootBoss("red");
			shooting_cooldown = 0.1f;
		}
		else if (Input.GetKeyDown (KeyCode.K) && shooting_cooldown <= 0) 
		{
			current_laser = (GameObject)Instantiate(blueLaser, transform.position+new Vector3(75, 0, 0), Quaternion.identity);
			Invoke ("DestroyLaser", .05f);
			TBoss.shootBoss("blue");
			shooting_cooldown = 0.1f;
		}
		else if (Input.GetKeyDown (KeyCode.L) && shooting_cooldown <= 0) 
		{
			current_laser = (GameObject)Instantiate(greenLaser, transform.position+new Vector3(75, 0, 0), Quaternion.identity);
			Invoke ("DestroyLaser", .05f);
			TBoss.shootBoss("green");
			shooting_cooldown = 0.1f;
		}


		if (Input.GetKeyDown (KeyCode.O)) //activate boss
		{
			TBoss.moveBossOnScreen();
		}




		PlatformData platformData = current_platform.GetComponent<PlatformData>();
		if (platformData.teleportable()){
			transform.position = current_platform.transform.position + new Vector3(0f, platformData.offset(), 0f);
		}
		else{
			Application.LoadLevel("deathScene");
		}
	}

	void DestroyLaser(){
		Destroy (current_laser);
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