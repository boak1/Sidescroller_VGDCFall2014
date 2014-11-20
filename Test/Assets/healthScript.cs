using UnityEngine;
using System.Collections;

public class healthScript : MonoBehaviour {

	//get the hp sprites
	public Sprite fullHp; 
	public Sprite oneHitHP;
	public Sprite twoHitHP; 
	//used to change sprites
	private SpriteRenderer spriteRenderer; 
	// Use this for initialization
	void Start () {

		spriteRenderer = GetComponent<SpriteRenderer>(); //  the SpriteRenderer that is attached to the Gameobject
		if (spriteRenderer.sprite == null) // if the sprite  is empty// set the sprite to fullHP
			spriteRenderer.sprite = fullHp; 
	
	}
	
	// Update is called once per frame
	void Update () {
		int hpTest = PlayerController.hp;

		if ( hpTest== 2) {
			spriteRenderer.sprite= oneHitHP;//change the sprite to 2 hp
				}
		if (hpTest == 1) {
			spriteRenderer.sprite= twoHitHP; // chnage the sprite to 1 hp
		}
		if (hpTest == 0) {
			Application.LoadLevel ("deathscene"); //moves to game over screen
			
		}
	
	}
}
