using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class levelController : MonoBehaviour
{

	public treeBoss TBoss; //refference to the boss gameobject/script
	private bool newColor  = false;	//tells the script whether or not to change boss color

	public laserScript primaryLaser;
	private List<laserScript> allLasers;
	private double laserCycles = 0;
	private float laserCycleTime;
	private float laserChargeTime;
	private int pastLaserHeight1 = 3, pastLaserHeight2 = 0;
	private bool iWasFirst = true;

	// Use this for initialization
	void Start () {

		allLasers = new List<laserScript> ();
		allLasers.Add(primaryLaser);

	}
	
	// Update is called once per frame
	void Update () {


			if (newColor && TBoss.bossOnScreen){//changes the boss color/sprite
				TBoss.changeBoss();
				newColor = false;
			}
			
			if (laserCycles == 7){//counts down to and starts boss fight
				TBoss.moveBossOnScreen();

				//<--add more lasers(multiple at once)
				//<--offset laser timer
				//<--shorten laser timer
				laserCycles++; //makes the else if false so it doesn't keep getting called
			}
			else if(laserCycles == 3){
				//<--switch background;
				//<--start music
				//<--offset laser timer
				//<--shorten laser timer

				//clones primary laser so ther are two lasers firing now
				laserScript newLaserScript = (laserScript)Instantiate(primaryLaser, primaryLaser.transform.position, primaryLaser.transform.rotation);
				newLaserScript.notPrimary();//stops new laser from triggering events
				
				allLasers.Add(newLaserScript);
				laserCycles++;//makes the else if false so it doesn't keep getting called
				
			}
		}
		
		
	
	public void updateLaserInfo(){//tells levelcontoller that a new laser cycle has gone by
		laserCycles++;
		newColor = true;
	}

	public int getLaserHeight(){//makes sure no two lasers are at the same height, returns an int between 0 and 3
		while (true){
			int temp = Random.Range(0, 4);//picks a random laser height
			//Debug.Log ("" + temp + pastLaserHeight1 + pastLaserHeight2);

			if(temp != pastLaserHeight1 && temp != pastLaserHeight2){//makes sure other lasers aren't firing there
				pastLaserHeight2 = pastLaserHeight1;
				pastLaserHeight1 = temp;
				//Debug.Log (" || " + temp + pastLaserHeight1 + pastLaserHeight2);
				return temp;
			}

		}
	}

	public bool getPrimaryLaser(){
		if (iWasFirst) {
			iWasFirst = false;
			//Debug.Log ("primary chosen");
			return true;
		}
		//Debug.Log ("don't want " + iWasFirst);

		return false;
	}

	public float getLaserCycleTime(){
		return laserCycleTime;
	}
	public float getLaserChargeTime(){
		return laserChargeTime;
	}
}