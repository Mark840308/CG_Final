using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mission2 : MonoBehaviour {

	private bool Correct = false;
	private int attempt = 0;
	private float angle;
	public GameObject mission1;
	public GameObject mission2;
	public GameObject mission3;

	void OnTriggerEnter(Collider other){
		if (other.gameObject.CompareTag ("mission2trigger")) {
			if (other.name == "trigger0") {
				other.gameObject.SetActive (false);
				mission1.gameObject.SetActive (false);
				mission2.transform.Find ("Building/Well").gameObject.SetActive (true);
				mission2.transform.Find ("Trigger/trigger6").gameObject.SetActive (true);
				mission2.transform.Find ("Discourse/discourse2").gameObject.SetActive (true);
				angle = 2f*Mathf.PI*mission2.transform.eulerAngles.y/360f;
			}
			if (!Correct) {
				attempt = attempt + 1;
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
					mission2.gameObject.SetActive (false);
					mission3.gameObject.SetActive (true);
					mission3.transform.rotation = mission2.transform.rotation;
					transform.position = transform.position - mission2.transform.position + new Vector3 (2.4f * Mathf.Cos (angle) - 51.5f * Mathf.Sin (angle), 45f, -51.5f * Mathf.Cos (angle) - 2.4f * Mathf.Sin (angle));
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
			if (other.name == "trigger6") {
				Correct = true;
				other.gameObject.SetActive (false);
				mission2.transform.Find ("Building/Question/Question_yes").gameObject.SetActive (true);
				mission2.transform.Find ("Building/Question/Question_no").gameObject.SetActive (false);
			}
		}

		if (attempt >= 3) {
			mission2.transform.Find ("Discourse/discourse1").gameObject.SetActive (true);
		}
	}


}
