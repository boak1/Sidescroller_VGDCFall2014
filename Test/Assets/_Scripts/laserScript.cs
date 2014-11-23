using UnityEngine;
using System.Collections;

public class laserScript : MonoBehaviour {
	//these are picutres of sprites
	public Sprite preLaser;
	public Sprite postLaser;
	public Sprite invisible;

	//these are timing floats for laser duration
	private float cooldown;
	public float cooldownStart;


	private SpriteRenderer spriteRenderL; //switches between sprites
	private Animator animator;// switches between animations
	public int countdownToBoss; // number of laser cycles before boss appears
	public treeBoss TBoss; //refference to the boss gameobject/script
	private bool newColor;	//tells the script whether or not to change boss color
	private bool changeHeight;
	// Use this for initialization
	void Start () {
		spriteRenderL = GetComponent<SpriteRenderer>();
		spriteRenderL.sprite = invisible;
		cooldown = cooldownStart;
		newColor = false;
		changeHeight = false;
		countdownToBoss = 6; 
		animator = GetComponent<Animator>();

	}
	
	// Update is called once per frame
	void Update () {
		cooldown -= Time.deltaTime;//transitions through the laser cycle

		if (cooldown > 0.1 && cooldown <= 1.1) {//time to charge attack
			animator.SetInteger("on_off", 1);//this is the code to change a value in an animator

		} 
		else if (cooldown > 0 && cooldown <= 0.1) {//time to fire attack
			animator.SetInteger("on_off", 2);
			spriteRenderL.sprite = postLaser;
			if (newColor && TBoss.bossOnScreen){//changes the boss color/sprite
				TBoss.changeBoss();
				newColor = false;
			}
				} 
		else if(cooldown <= 0){//turn laser off, reset cycle
			animator.SetInteger("on_off", 0);

			spriteRenderL.sprite = invisible;
			cooldown = cooldownStart;
			newColor = true;
			changeHeight = true;

			if (countdownToBoss == 0)//counts down to and starts boss fight
				TBoss.moveBossOnScreen();
			else if(countdownToBoss > 0)
				countdownToBoss--;
		}
		else {//turns off laser, waits, reposition's laser
			animator.SetInteger("on_off", 0);
			spriteRenderL.sprite = invisible;

			if (changeHeight)
			changeLaserHeight();//repositions laser
			changeHeight = false;
				}

	
	}

	public void changeLaserHeight(){//randomly repositions the laser
		switch (Random.Range(0, 4))
		{
		case 3:
			transform.position = new Vector3(transform.position.x, -38f, transform.position.z);
			break;
		case 2:
			transform.position = new Vector3(transform.position.x, -21f, transform.position.z);
			break;
		case 1:
			transform.position = new Vector3(transform.position.x, 5f, transform.position.z);
			break;		
		case 0:
			transform.position = new Vector3(transform.position.x, 25f, transform.position.z);
			break;
		default:
			transform.position = new Vector3(transform.position.x, 6f, transform.position.z);
			break;
		}
		}

	void OnTriggerStay2D(Collider2D hitInfo){//damages player if they hit the laser
		//Debug.Log ("You got hit");

		if (hitInfo.name == "Player" && spriteRenderL.sprite == postLaser) {
			PlayerController.hp -= 1;
		}
	}

}
