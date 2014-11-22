using UnityEngine;
using System.Collections;

public class laserScript : MonoBehaviour {
	//these are picutres of sprites
	public Sprite preLaser;
	public Sprite postLaser;
	private float cooldown;
	public float cooldownStart;

	private SpriteRenderer spriteRenderL;

	// Use this for initialization
	void Start () {
		//spriteRenderL = GetComponent<SpriteRenderer>();
		//if (spriteRenderL.sprite == null)
		//spriteRenderL.sprite = preLaser;
		cooldown = cooldownStart;
	
	}
	
	// Update is called once per frame
	void Update () {
		cooldown -= Time.deltaTime;
		if (cooldown == 1) {
			spriteRenderL.sprite = preLaser;

				} 
		else if (cooldown == 0) {
			spriteRenderL.sprite = postLaser;
			cooldown = cooldownStart;
				} 
		else {
			spriteRenderL.sprite = null;
				}

	
	}

}
