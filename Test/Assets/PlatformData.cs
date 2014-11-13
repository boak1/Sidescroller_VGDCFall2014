using UnityEngine;
using System.Collections;

public class PlatformData : MonoBehaviour {
	public float offsetValue;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3(transform.position.x-0.2f, transform.position.y, transform.position.z);
	}

	public float offset(){
		return offsetValue;
	}
}
