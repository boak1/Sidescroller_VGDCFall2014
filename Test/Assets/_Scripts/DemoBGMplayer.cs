using UnityEngine;
using System.Collections;

/* TODO:
 * Have music immediately switch to the 'intense' loop when the boss appears instead of waiting until current loop finishes
 */

public class DemoBGMplayer : MonoBehaviour {

    public float bpm = 157.0f;				//clips are 157 bpm (314 bpm but in half-time)
    public int numBeatsPerSegment = 32;	    //each clip is 8 measures long at 157 bpm; 8 measures * 4 beats per measure = 32
    public AudioClip[] clips = new AudioClip[3];
    public levelController level;
    public float fadeInRate = .26f;          //specifies how fast to fade in the first clip at startup (true rate is fadeInRate * Time.deltaTime)

    private double nextEventTime;
    private int clipIndex = 0;
    private int audioSourceIndex = 0;
    private AudioSource[] audioSources = new AudioSource[2];
    private bool running = false;

	// Use this for initialization
	void Start () {
        int i = 0;
        while (i < 2)
        {
            GameObject child = new GameObject("Player");
            child.transform.parent = gameObject.transform;
            audioSources[i] = child.AddComponent("AudioSource") as AudioSource;
            i++;
        }
        nextEventTime = AudioSettings.dspTime;	//add a float to this line to specify a delay b/w game startup and music start
        running = true;
        audioSources[0].volume = 0.0f;   
	}
	
	// Update is called once per frame
	void Update () {
        if (!running)
            return;
        if (audioSources[0].volume < 1.0f)
        {
            audioSources[0].volume += Time.deltaTime * fadeInRate;
        }


        double time = AudioSettings.dspTime;
        if (level.isTreeBossOnScreen())
        {
            clipIndex = 2;		//keep loading clip[0] until the boss appears, then load clip[1]
        }
        if (time + 1.0f > nextEventTime)
        {
            audioSources[audioSourceIndex].clip = clips[clipIndex];
            audioSources[audioSourceIndex].PlayScheduled(nextEventTime);
            Debug.Log("Scheduled source " + clipIndex + " to start at time " + nextEventTime);
            nextEventTime += 60.0F / bpm * numBeatsPerSegment;
            audioSourceIndex = 1 - audioSourceIndex;
            clipIndex = 1;
        }
	}
}
