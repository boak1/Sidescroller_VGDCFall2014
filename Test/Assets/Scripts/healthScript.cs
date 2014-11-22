using UnityEngine;
using System.Collections;

public class healthScript : MonoBehaviour {

	//get the hp sprites
	public Sprite fullHp; 
	public Sprite oneHitHP;
	public Sprite twoHitHP; 
	//used to change sprites
	private SpriteRenderer spriteRendererH; 
	// Use this for initialization
	void Start () {

		spriteRendererH = GetComponent<SpriteRenderer>(); //  the SpriteRenderer that is attached to the Gameobject
		if (spriteRendererH.sprite == null) // if the sprite  is empty// set the sprite to fullHP
			spriteRendererH.sprite = fullHp; 
	
	}
	
	// Update is called once per frame
	void Update () {
		int hpTest = PlayerController.hp;

		if ( hpTest== 2) {
			spriteRendererH.sprite= oneHitHP;//change the sprite to 2 hp
				}
		else if (hpTest == 1) {
			spriteRendererH.sprite= twoHitHP; // chnage the sprite to 1 hp
		}
		else if (hpTest == 0) {
			Application.LoadLevel ("deathscene"); //moves to game over screen
			
		}
	
	}
}
