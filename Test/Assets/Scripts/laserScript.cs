using UnityEngine;
using System.Collections;

public class laserScript : MonoBehaviour {
	//these are picutres of sprites
	public Sprite preLaser;
	public Sprite postLaser;
	public Sprite invisible;
	private float cooldown;
	public float cooldownStart;

	private SpriteRenderer spriteRenderL;

	public int countdownToBoss;
	public treeBoss TBoss;
	private bool newColor;
	// Use this for initialization
	void Start () {
		spriteRenderL = GetComponent<SpriteRenderer>();
		if (spriteRenderL.sprite == null)
		spriteRenderL.sprite = invisible;
		cooldown = cooldownStart;
		newColor = false;
		countdownToBoss = 6;
	}
	
	// Update is called once per frame
	void Update () {
		cooldown -= Time.deltaTime;
		if (cooldown > 0.1 && cooldown <= 1.1) {
			spriteRenderL.sprite = preLaser;

				} 
		else if (cooldown > 0 && cooldown <= 0.1) {
			spriteRenderL.sprite = postLaser;
			if (newColor && TBoss.bossOnScreen){
				TBoss.changeBoss();
				newColor = false;
			}
				} 
		else if(cooldown <= 0){
			spriteRenderL.sprite = invisible;
			cooldown = cooldownStart;
			newColor = true;
			changeLaserHeight();
			if (countdownToBoss == 0)
				TBoss.moveBossOnScreen();
			else if(countdownToBoss > 0)
				countdownToBoss--;
		}
		else {
			spriteRenderL.sprite = invisible;

				}

	
	}

	public void changeLaserHeight(){
		switch (Random.Range(0, 3))
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

	void OnTriggerStay2D(Collider2D hitInfo){
		//Debug.Log ("You got hit");

		if (hitInfo.name == "Player" && spriteRenderL.sprite == postLaser) {
			PlayerController.hp -= 1;
		}
	}

}
