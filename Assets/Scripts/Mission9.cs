using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mission9 : MonoBehaviour {

	public GameObject mission9;
	public GameObject mission10;

	private int RotateAngle = 0;
	private bool nextRoad = false;

	void FixedUpdate(){
		if (RotateAngle != 0) {
			DoorRotate ();
			if (RotateAngle == 0) {
				StopRotate ();
			}
		}
	}
		

	void OnTriggerEnter(Collider other){
		float angleM = mission9.transform.eulerAngles.y;
		if (angleM > 180) {
			angleM = angleM - 360;
		}
		if (other.gameObject.CompareTag ("mission9trigger")) {
			if (other.name == "trigger1") {
				other.gameObject.SetActive (false);
				mission10.transform.position = mission9.transform.Find ("Building/Loby2").gameObject.transform.position;
				mission10.transform.rotation = mission9.transform.Find ("Building/Loby2").gameObject.transform.rotation;
				mission10.gameObject.SetActive (true);
				GetComponent<Mission10> ().enabled = true;
				mission9.gameObject.SetActive (false);
				GameObject.Find ("backgroundMusic1").gameObject.SetActive (false);
				GameObject.Find ("backgroundMusic2").gameObject.SetActive (false);
				mission10.transform.Find("Building/warningMusic").gameObject.SetActive(true);
			}
		}
	}

	void DoorRotate(){
		mission9.transform.Find ("Building/Door").transform.Rotate (0f, -1f, 0f);
		RotateAngle = RotateAngle - 1;
	}

	public void StartRotate(){
		if (!nextRoad) {
			RotateAngle = 90;
			mission9.transform.Find ("Building/Door/openDoor").GetComponent<AudioSource> ().Play ();
			nextRoad = true;
		}
	}

	void StopRotate(){
		mission9.transform.Find ("Building/Door/openDoor").GetComponent<AudioSource> ().Stop ();
	}
		
}
