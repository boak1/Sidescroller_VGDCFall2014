using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class levelController : MonoBehaviour
{

	public treeBoss TBoss; //refference to the boss gameobject/script
	private bool newColor;	//tells the script whether or not to change boss color

	public laserScript primaryLaser;
	private List<laserScript> allLasers;
	private int laserCycles;
	private float laserCycleTime;
	private float laserChargeTime;
	private int pastLaserHeight1 = 3, pastLaserHeight2 = 0;
	private bool iWasFirst = true;

	// Use this for initialization
	void Start () {
		newColor = false;
		laserCycles = 0;

		allLasers = new List<laserScript> ();
		allLasers.Add(primaryLaser);

	}
	
	// Update is called once per frame
	void Update () {


			if (newColor && TBoss.bossOnScreen){//changes the boss color/sprite
				TBoss.changeBoss();
				newColor = false;
			}
			
			if (laserCycles == 6){//counts down to and starts boss fight
				TBoss.moveBossOnScreen();
				//change laser timer
				//add more lasers(multiple at once)
			}
			else if(laserCycles == 50){
				//switch background;
				//start music
				//timeToPrelaser = .5f;//less time to react
				//cooldownStart = 2f;
				//more lasers
			laserScript newLaserScript = (laserScript)Instantiate(primaryLaser, primaryLaser.transform.position, primaryLaser.transform.rotation);

			newLaserScript.notPrimary();

		//	allLasers.Add(newLaserScript);
		//	newLaserScript.levelControl = this;
			}
		}
		
		
	
	public void updateLaserInfo(){//tells levelcontoller that a new laser cycle has gone by
		laserCycles++;
		newColor = true;
	}

	public int getLaserHeight(){//makes sure no two lasers are at the same height, returns an int between 0 and 3
		while (true){
			int temp = Random.Range(0, 4);
			Debug.Log ("" + temp + pastLaserHeight1 + pastLaserHeight2);

			if(temp != pastLaserHeight1 && temp != pastLaserHeight2){
				pastLaserHeight2 = pastLaserHeight1;
				pastLaserHeight1 = temp;
				Debug.Log (" || " + temp + pastLaserHeight1 + pastLaserHeight2);
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