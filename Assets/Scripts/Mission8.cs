using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mission8 : MonoBehaviour {


	private bool Correct = false;
	private float angle;
	public GameObject mission3;
	public GameObject mission4;
	public GameObject start;
	public GameObject mission5;
	public GameObject mission6;
	public GameObject mission7;
	public GameObject mission8;
	public GameObject mission9;

	private int MaxTime = 750;
	private int WaitTime = 0;
	private Vector3 TmpPosition;

	void FixedUpdate(){
		if (transform.position == TmpPosition) {
			WaitTime = WaitTime + 1;
			if (WaitTime >= MaxTime) {
				Correct = true;
				ChangeQuestionAnswer ();
			}
		} else {
			WaitTime = 0;
		}
		TmpPosition = transform.position;
		//print (WaitTime);
	}

	void OnTriggerEnter(Collider other){
		if (other.gameObject.CompareTag ("mission8trigger")) {
			if (other.name == "trigger0") {
				other.gameObject.SetActive (false);
				mission3.gameObject.SetActive (false);
				mission4.gameObject.SetActive (false);
				start.gameObject.SetActive (false);
				mission5.gameObject.SetActive (false);
				mission6.gameObject.SetActive (false);
				mission7.gameObject.SetActive (false);
				mission8.transform.Find ("Building/Well").gameObject.SetActive (true);
				angle = 2f*Mathf.PI*mission8.transform.eulerAngles.y/360f;
			}
			if (!Correct) {
				if (other.name == "trigger1") {
					transform.position = transform.position + new Vector3 (4.8f * Mathf.Cos (angle) + 53.5f * Mathf.Sin (angle), 45f, 53.5f * Mathf.Cos (angle) - 4.8f * Mathf.Sin (angle));
				}
				if (other.name == "trigger2") {
					transform.position = transform.position + new Vector3 (2.4f * Mathf.Cos (angle) + 53.5f * Mathf.Sin (angle), 45f, 53.5f * Mathf.Cos (angle) - 2.4f * Mathf.Sin (angle));
				}
				if (other.name == "trigger3") {
					transform.position = transform.position + new Vector3 (0f * Mathf.Cos (angle) + 53.5f * Mathf.Sin (angle), 45f, 53.5f * Mathf.Cos (angle) + 0f * Mathf.Sin (angle));
				}
				if (other.name == "trigger4") {
					transform.position = transform.position + new Vector3 (-2.4f * Mathf.Cos (angle) + 53.5f * Mathf.Sin (angle), 45f, 53.5f * Mathf.Cos (angle) + 2.4f * Mathf.Sin (angle));
				}
				if (other.name == "trigger5") {
					transform.position = transform.position + new Vector3 (-4.8f * Mathf.Cos (angle) + 53.5f * Mathf.Sin (angle), 45f, 53.5f * Mathf.Cos (angle) + 4.8f * Mathf.Sin (angle));
				}
			}
			if (Correct) {
				if (other.name == "trigger1") {
					transform.position = transform.position + new Vector3 (4.8f * Mathf.Cos (angle) + 53.5f * Mathf.Sin (angle), 45f, 53.5f * Mathf.Cos (angle) - 4.8f * Mathf.Sin (angle));
				}
				if (other.name == "trigger2") {
					mission8.gameObject.SetActive (false);
					mission9.gameObject.SetActive (true);
					mission9.transform.rotation = mission8.transform.rotation;
					transform.position = transform.position - mission8.transform.position + new Vector3 (2.4f * Mathf.Cos (angle) - 51.5f * Mathf.Sin (angle), 45f, -51.5f * Mathf.Cos (angle) - 2.4f * Mathf.Sin (angle));
				}
				if (other.name == "trigger3") {
					transform.position = transform.position + new Vector3 (0f * Mathf.Cos (angle) + 53.5f * Mathf.Sin (angle), 45f, 53.5f * Mathf.Cos (angle) + 0f * Mathf.Sin (angle));
				}
				if (other.name == "trigger4") {
					transform.position = transform.position + new Vector3 (-2.4f * Mathf.Cos (angle) + 53.5f * Mathf.Sin (angle), 45f, 53.5f * Mathf.Cos (angle) + 2.4f * Mathf.Sin (angle));
				}
				if (other.name == "trigger5") {
					transform.position = transform.position + new Vector3 (-4.8f * Mathf.Cos (angle) + 53.5f * Mathf.Sin (angle), 45f, 53.5f * Mathf.Cos (angle) + 4.8f * Mathf.Sin (angle));
				}
			}
		}
	}

	void ChangeQuestionAnswer(){
		mission8.transform.Find ("Building/Question/Question_yes").gameObject.SetActive (true);
		mission8.transform.Find ("Building/Question/Question_no").gameObject.SetActive (false);
		mission8.transform.Find ("Building/Answer/Answer_yes").gameObject.SetActive (true);
		mission8.transform.Find ("Building/Answer/Answer_no").gameObject.SetActive (false);
	}

}
