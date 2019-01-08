using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirrorRotate : MonoBehaviour {

	private int count = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (count != 0) {
			transform.Rotate (new Vector3 (1, 0, 0));
			count = count - 1;
		}
	}

	public void StartRotate(){
		if (count == 0) {
			count = 90;
		}
	}
}
