using UnityEngine;
using System.Collections;

/*I literally copied this from the Unity doc website so I don't fully understand how it works 
 *       --Vincent
 * 
 * Plays clip1, starts loading clip2 into buffer 1 second before clip2 starts playing
 * After that, keeps loading clip2 into buffer 1 second before clip2 ends
 * 
 * TODO:
 * make clips playback in stereo, not mono
 * make clips playback at correct volume; right now they play back at a very low volume
 * cut better loop clips from original track .wav export
 */

[RequireComponent(typeof(AudioSource))]
public class bgmMergeClipsAndLoop : MonoBehaviour {
	public float bpm = 120.0F;
	public int numBeatsPerSegment = 224;
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
		nextEventTime = AudioSettings.dspTime + 2.0F;
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
			index = 1;
		}
	}
}