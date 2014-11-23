using UnityEngine;
using System.Collections;

public class platformSwitch : MonoBehaviour
{
	public Sprite letterPlatform;
	public Sprite blankPlatform; 
	private SpriteRenderer spriteRendererH; 

	public bool letters;

		// Use this for initialization
		void Start (){
			spriteRendererH = GetComponent<SpriteRenderer>(); //  the SpriteRenderer that is attached to the Gameobject
			if (spriteRendererH.sprite == null) // if the sprite  is empty// set the sprite to fullHP
				spriteRendererH.sprite = letterPlatform; 

			letters = true;
		}
	
		// Update is called once per frame
		void Update (){
		if (Input.GetKeyDown (KeyCode.P)) //toggle letters
			toggleLetters();

		}

	public void toggleLetters(){
		if (letters) {
			spriteRendererH.sprite = blankPlatform;
			letters = false;
		}
		else 
			spriteRendererH.sprite = letterPlatform; 
		
	}

}