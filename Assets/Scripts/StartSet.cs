using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartSet : MonoBehaviour {

	public GameObject start;
	public GameObject mission5;

	void OnTriggerEnter(Collider other){
		if (other.gameObject.CompareTag ("startTrigger")) {
			if (other.name == "trigger1") {
				Vector3 angle = 2f * Mathf.PI * start.transform.eulerAngles / 360f;
				mission5.gameObject.SetActive (true);
				mission5.transform.position = start.transform.position + new Vector3 (-60f * Mathf.Sin (angle.y), -11f, -60f * Mathf.Cos (angle.y));
				mission5.transform.rotation = start.transform.rotation;
				other.gameObject.SetActive (false);
			}
		}
	}
}
