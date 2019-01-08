using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mission0 : MonoBehaviour {

	public GameObject mission0;
	public GameObject mission1;

	public void OpenDoor(){
		mission0.transform.Find ("Device/Portal").gameObject.SetActive (true);
	}

	public void CloseDoor(){
		mission0.transform.Find ("Device/Portal").gameObject.SetActive (false);
	}

	void OnTriggerEnter(Collider other){
		if (other.gameObject.CompareTag ("mission0trigger")) {
			if (other.name == "trigger") {
				mission0.gameObject.SetActive (false);
				mission1.gameObject.SetActive (true);
				transform.position = new Vector3 (0f, 0f, 0f);
			}
		}
	}

	public void mirrorRotate (string name){
		mission0.transform.Find ("Device/Mirror/" + name).gameObject.GetComponent<MirrorRotate> ().StartRotate ();
	}

}
