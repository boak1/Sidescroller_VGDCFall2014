using UnityEngine;
using System.Collections;

/* I literally copied this from the Unity doc website, so hopefully it'll work well enough for now
 *       --Vincent
 * 
 * Uses an array of 2 audio clips in Audioclip[] clip
 * Loads clip[0] into memory and starts playback upon game startup
 * One second before clip[0] reaches the end, loads clip[1] into memory buffer
 * After clip[1] starts playing, it will keep loading and looping clip[1]
 * 
 * NOTE: script is dependent on variables bpm and numBeatsPerSegment for timing the loading and playback of clips
 */

[RequireComponent(typeof(AudioSource))]
public class bgmMergeClipsAndLoop : MonoBehaviour {
	public float bpm = 120.0F;				//both clips are at 120 bpm
	public int numBeatsPerSegment = 224;	//each clip is 56 measures long; 56 measures * 4 beats per measure = 224
	public AudioClip[] clips = new AudioClip[2];
	private double nextEventTime;
	private int index = 0;
	private AudioSource[] audioSources = new AudioSource[2];
	private bool running = false;

	void Start() {
		int i = 0;
		while (i < 2) {
			GameObject child = new GameObject("Player");
			child.transform.parent = gameObject.transform;
			audioSources[i] = child.AddComponent("AudioSource") as AudioSource;
			i++;
		}
		nextEventTime = AudioSettings.dspTime;	//add a float to this line to specify a delay b/w game startup and music playback
		running = true;
	}

	void Update() {
		if (!running)
			return;
		
		double time = AudioSettings.dspTime;
		if (time + 1.0F > nextEventTime) {
			audioSources[index].clip = clips[index];
			audioSources[index].PlayScheduled(nextEventTime);
			Debug.Log("Scheduled source " + index + " to start at time " + nextEventTime);
			nextEventTime += 60.0F / bpm * numBeatsPerSegment;
			index = 1;		//after clip[0] plays, we only need to play clip[1] until game exit
		}
	}
}