using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class PlatformData : MonoBehaviour {
	public float offsetValue;
	// Use this for initialization
	float platMoveY;
	float startY;

	void Start () {
		offsetValue = 7.2f;
		platMoveY = .03f;
		startY = transform.position.y;
		transform.position = new Vector3(transform.position.x, transform.position.y + Random.Range (1,35)/100f, transform.position.z);
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3(transform.position.x-0.2f, transform.position.y + platMoveY, transform.position.z);

		if( transform.position.y - .2 >= startY && platMoveY > 0)
		platMoveY *= -1;
		else if(transform.position.y  + .2 <= startY && platMoveY < 0)
		platMoveY *= -1;

	}

	public float offset(){
		return offsetValue;
	}


}
