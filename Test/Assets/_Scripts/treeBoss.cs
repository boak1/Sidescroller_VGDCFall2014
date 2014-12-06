using UnityEngine;
using System.Collections;
	public class treeBoss : MonoBehaviour {
		//tree sprites and renderer
	public Sprite normalBoss; 
	public Sprite greenBoss; 
	public Sprite blueBoss;
	public Sprite redBoss; 
	private SpriteRenderer bossRender;

    public int maxBossHP = 20; 
	public int bossHP = 20; //boss health
	private int bossColor; //0 to 3 : normal to red
	public bool bossOnScreen, bossWasShot, moved; //whether or not boss should be on the screen
	public string laserColor;

	public GameObject healthBar;
	// Use this for initialization
	void Start () {
			
				
		bossRender = GetComponent<SpriteRenderer>(); //  the SpriteRenderer that is attached to the Gameobject
		if (bossRender.sprite == null) // if the sprite  is empty// set the sprite to normalBoss
			bossRender.sprite = normalBoss; 

		//boss starts with normal sprite, off screen, with "bossHP" health
		bossHP = 20;
		bossOnScreen = false;
		bossColor = 0;
		moved = false;

		bossWasShot = false;
		laserColor = "";

	}
			
	// Update is called once per frame
	void Update () {
		if(bossHP <=0)
			Application.LoadLevel ("winscene"); //moves to game Win screen

		if (bossOnScreen && !moved){
			transform.position = new Vector3 (50f, transform.position.y, transform.position.z);
			moved = true;
		}

		if(bossOnScreen && bossWasShot){//if boss is on screen (damageable)
			if (bossRender.sprite == redBoss && laserColor == "red" ||
			    bossRender.sprite == blueBoss && laserColor == "blue" ||
			    bossRender.sprite == greenBoss && laserColor == "green" ){
				bossHP--; //if player fired right laser damage boss
				healthBar.transform.position += new Vector3(1.5f, 0,0);
				//Debug.Log(bossHP);
			}
			else 
				PlayerController.hp--;//if player fired inappropriatley they take damage
			bossWasShot = false;
		}
	}

	public void moveBossOnScreen( ){

		bossOnScreen = true;//makes boss damageable

	}

			
	public void shootBoss(string LColor){
		laserColor = LColor;
		bossWasShot = true;
	}

	public void changeBoss(){//randomly changes boss to a diffrent color

		bossColor = (bossColor + Random.Range(1, 3)) % 4;
		//Debug.Log (bossColor);
		switch (bossColor)
		{
		case 3:
			bossRender.sprite = redBoss;
			break;
		case 2:
			bossRender.sprite = blueBoss;
			break;
		case 1:
			bossRender.sprite = greenBoss;
			break;
		default:
			bossRender.sprite = normalBoss;
			break;
		}
	}
			
}
