using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayBeam : MonoBehaviour {

	private int count = 0;
	private Vector3 startPoint = new Vector3 (0, 0, 0);


	// Use this for initialization
	void Start () {
		startPoint = transform.position;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		
		count = 0;
		Reset ();
		Ray ray = new Ray ();
		ray.origin = startPoint;
		ray.direction = new Vector3 (0, 1, 0);
		RaycastHit hit;
		int bug = 0;
		while (Physics.Raycast(ray, out hit)){
			Vector3 fromPoint = ray.origin;
			Vector3 toPoint   = hit.transform.position;
			AddObject (fromPoint, toPoint);
			//print (fromPoint.ToString()+toPoint.ToString()+count.ToString());
			if (hit.transform.tag == "mirror") {
				ray.origin = hit.transform.position;
				ray.direction = Vector3.Reflect (ray.direction, hit.normal);
			} else if (hit.transform.tag == "sensor" && count == 13) {
				GameObject.Find ("FPSController").GetComponent<Mission0> ().OpenDoor ();
				break;
			} else {
				break;
			}
			bug = bug + 1;
			if (bug > 100) {
				break;
			}
		}
		if (!Physics.Raycast (ray, out hit)) {
			AddObject (ray.origin, ray.origin+500.0f*ray.direction);
		}

	}

	void AddObject(Vector3 fromPoint, Vector3 ToPoint){
		count = count + 1;
		GameObject laser = (GameObject)Instantiate (Resources.Load ("laser"));
		laser.name = "laser" + count.ToString ();
		laser.transform.parent = transform;
		laser.transform.position = new Vector3 (0, 0, 0);
		laser.GetComponent<LineRenderer> ().SetPosition (0, fromPoint);
		laser.GetComponent<LineRenderer> ().SetPosition (1, ToPoint);
	}

	void Reset(){
		DeleteObject ();
		GameObject.Find ("FPSController").GetComponent<Mission0> ().CloseDoor ();
	}

	void DeleteObject(){
		for (int i = 0; i < transform.childCount; i++) {
			GameObject go = transform.GetChild (i).gameObject;
			Destroy (go);
		}
	}

}
