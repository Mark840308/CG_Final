using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mission7 : MonoBehaviour {

	public GameObject mission7;
	public GameObject mission8;

	void OnTriggerEnter(Collider other){
		if (other.gameObject.CompareTag ("mission7trigger")) {
			if (other.name == "trigger1") {
				Vector3 displacement = other.transform.position - mission7.transform.Find ("Trigger/trigger2").gameObject.transform.position;
				transform.position = transform.position - displacement*0.4f;
			}
			if (other.name == "trigger2") {
				other.gameObject.SetActive (false);
				mission7.transform.Find ("Building/Pass1").gameObject.SetActive (false);
				mission7.transform.Find ("Building/HoleWall").gameObject.SetActive (true);
				mission7.transform.Find ("Discourse/discourse1").gameObject.SetActive (true);
				Vector3 angle = 2f*Mathf.PI*mission7.transform.eulerAngles/360f;
				GetComponent<Mission8> ().enabled = true;
				mission8.transform.position = mission7.transform.position + new Vector3 (-49f*Mathf.Sin(angle.y)-38.5f*Mathf.Cos(angle.y), 0f, -49f*Mathf.Cos(angle.y)+38.5f*Mathf.Sin(angle.y));
				mission8.transform.rotation = Quaternion.Euler (0f, mission7.transform.eulerAngles.y + 90f, 0f);
				mission8.gameObject.SetActive (true);
			}
		}


	}

}
