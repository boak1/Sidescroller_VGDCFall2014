using UnityEngine;
using System.Collections;

/* BUGS:
 * When the next clip to be played is the same as before, the last second of the currently playing clip does not play
 *      Lazy workaround: increase .
 */

public class DemoBGMplayer : MonoBehaviour {

    public float bpm = 157.0f;				//clips are 157 bpm (314 bpm but in half-time)
    public int numBeatsPerSegment = 32;	    //each clip is 8 measures long at 157 bpm; 8 measures * 4 beats per measure = 32
    public AudioClip[] clips = new AudioClip[2];
    private double nextEventTime;
    private int clipIndex = 0;
    private int audioSourceFlip = 0;
    private AudioSource[] audioSources = new AudioSource[2];
    private bool running = false;
    public levelController level;

	// Use this for initialization
	void Start () {
        //laserCycles = level.getLaserCycleNumber();                  //for some reason this is not getting set properly
        int i = 0;
        while (i < 2)
        {
            GameObject child = new GameObject("Player");
            child.transform.parent = gameObject.transform;
            audioSources[i] = child.AddComponent("AudioSource") as AudioSource;
            //audioSources[i].volume = .8f;
            i++;
        }
        nextEventTime = AudioSettings.dspTime;	//add a float to this line to specify a delay b/w game startup and music start
        running = true;
	}
	
	// Update is called once per frame
	void Update () {
        if (!running)
            return;

        double time = AudioSettings.dspTime;
        if (level.isTreeBossOnScreen())
        {
            clipIndex = 1;		//keep loading clip[0] until the boss appears
        } else {
            clipIndex = 0;
        }
        if (time + 1.0f > nextEventTime)
        {
            audioSources[audioSourceFlip].clip = clips[clipIndex];
            audioSources[audioSourceFlip].PlayScheduled(nextEventTime);
            Debug.Log("Scheduled source " + clipIndex + " to start at time " + nextEventTime);
            nextEventTime += 60.0F / bpm * numBeatsPerSegment;
            audioSourceFlip = 1 - audioSourceFlip;
        }
	}
}
