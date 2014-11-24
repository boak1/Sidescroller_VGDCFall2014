﻿using UnityEngine;
using System.Collections;

public class laserScript : MonoBehaviour {
	//these are picutres of sprites
	public Sprite preLaser;
	public Sprite postLaser;
	public Sprite invisible;

	//these are timing floats for laser duration
	private float cooldown;
	public float cooldownStart;

	public levelController levelControl;

	private SpriteRenderer spriteRenderL; //switches between sprites
	private Animator animator;// switches between animations

	private bool changeHeight;
	private bool canHitPlayer;
	private float timeToPrelaser;// Use this for initialization
	public bool primaryLaser;

	void Start () {
		spriteRenderL = GetComponent<SpriteRenderer>();
		spriteRenderL.sprite = invisible;
		cooldown = cooldownStart;
		changeHeight = false;
		animator = GetComponent<Animator>();
		canHitPlayer = true;
		changeLaserHeight ();
		timeToPrelaser = 1.1f;
		primaryLaser = levelControl.getPrimaryLaser();
	}
	
	// Update is called once per frame
	void Update () {
		cooldown -= Time.deltaTime;//transitions through the laser cycle

		if (cooldown > 0.1 && cooldown <= timeToPrelaser) {//time to charge attack
			animator.SetInteger("on_off", 1);//this is the code to change a value in an animator

		} 
		else if (cooldown > 0 && cooldown <= 0.1) {//time to fire attack
			animator.SetInteger("on_off", 2);
			spriteRenderL.sprite = postLaser;
		} 
		else if(cooldown <= 0){//turn laser off, reset cycle
			animator.SetInteger("on_off", 0);

			spriteRenderL.sprite = invisible;
			cooldown = cooldownStart;
			changeHeight = true;

			if(primaryLaser)
			levelControl.updateLaserInfo();
		}

		else {//turns off laser, waits, reposition's laser
			animator.SetInteger("on_off", 0);
			spriteRenderL.sprite = invisible;
			canHitPlayer = true;

			if (changeHeight)
			changeLaserHeight();//repositions laser
			changeHeight = false;
		}

	
	}

	public void changeLaserHeight(){//randomly repositions the laser
		switch (levelControl.getLaserHeight())
		{
		case 3:
			transform.position = new Vector3(transform.position.x, -39f, transform.position.z);
			break;
		case 2:
			transform.position = new Vector3(transform.position.x, -18f, transform.position.z);
			break;
		case 1:
			transform.position = new Vector3(transform.position.x, 8f, transform.position.z);
			break;		
		case 0:
			transform.position = new Vector3(transform.position.x, 28f, transform.position.z);
			break;
		default:
			transform.position = new Vector3(transform.position.x, -8f, transform.position.z);
			break;
		}
		}

	void OnTriggerStay2D(Collider2D hitInfo){//damages player if they hit the laser
		//Debug.Log ("You got hit");

		if (hitInfo.name == "Player" && canHitPlayer && animator.GetInteger("on_off") == 2) {
			PlayerController.hp -= 1;
			canHitPlayer = false;
		}
	}

	public void notPrimary(){
		primaryLaser = false;		
	}


}
