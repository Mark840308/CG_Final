using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointToObject : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit rayhit;
		Physics.Raycast (ray, out rayhit);
		if (Input.GetMouseButton (1)) {
			if (rayhit.transform.tag == "door") {
				GetComponent<Mission9> ().StartRotate ();
			}
			if (rayhit.transform.tag == "mirror") {
				GetComponent<Mission0> ().mirrorRotate (rayhit.transform.name);
			}
		}

	}
}
