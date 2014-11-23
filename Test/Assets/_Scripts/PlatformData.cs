using UnityEngine;
using System.Collections;

public class PlatformData : MonoBehaviour {
	public float offsetValue;
	// Use this for initialization
	float platMoveY;
	float startY;
	void Start () {
		offsetValue = 7.2f;
		platMoveY = .03f;
		startY = transform.position.y;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3(transform.position.x-0.2f, transform.position.y + platMoveY, transform.position.z);

		if(transform.position.y  + .2 <= startY || transform.position.y - .2 >= startY)
		platMoveY *= -1;
	}

	public float offset(){
		return offsetValue;
	}
}
