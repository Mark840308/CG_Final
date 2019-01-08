using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mission5 : MonoBehaviour {

	public GameObject mission5;
	public GameObject mission6;

	void OnTriggerEnter(Collider other){
		if (other.gameObject.CompareTag ("mission5trigger")) {
			if (other.name == "trigger1") {
				Vector3 angle = 2f * Mathf.PI * mission5.transform.eulerAngles / 360f;
				transform.position = transform.position + new Vector3 (60f * Mathf.Sin (angle.y), 162f, 60f * Mathf.Cos (angle.y));
				mission5.transform.Find ("Discourse/discourse1").gameObject.SetActive (true);
				mission5.transform.Find ("Building/Loby/Ground/Part1/ground1").gameObject.GetComponent<MeshRenderer> ().enabled = false;
				mission5.transform.Find ("Building/Loby/Ground/Part2/ground3").gameObject.GetComponent<MeshRenderer> ().enabled = false;
				mission5.transform.Find ("Building/Loby/Ground/Part3/ground5").gameObject.GetComponent<MeshRenderer> ().enabled = false;
				mission5.transform.Find ("Building/Loby/Ground/Part4/ground7").gameObject.GetComponent<MeshRenderer> ().enabled = false;
				mission5.transform.Find ("Building/Loby/Ground/Part5/ground9").gameObject.GetComponent<MeshRenderer> ().enabled = false;
				mission5.transform.Find ("Building/Loby/Ground/Part5/ground10").gameObject.GetComponent<MeshRenderer> ().enabled = false;
			}
			if (other.name == "trigger2") {
				mission5.transform.Find ("Building/Loby/Ground/Part2").gameObject.SetActive (true);
				mission5.transform.Find ("Trigger/trigger3").gameObject.SetActive (true);
				other.gameObject.SetActive (false);
			}
			if (other.name == "trigger3") {
				mission5.transform.Find ("Building/Loby/Ground/Part3").gameObject.SetActive (true);
				mission5.transform.Find ("Trigger/trigger4").gameObject.SetActive (true);
				other.gameObject.SetActive (false);
			}
			if (other.name == "trigger4") {
				mission5.transform.Find ("Building/Loby/Ground/Part4").gameObject.SetActive (true);
				mission5.transform.Find ("Trigger/trigger5").gameObject.SetActive (true);
				other.gameObject.SetActive (false);
			}
			if (other.name == "trigger5") {
				mission5.transform.Find ("Building/Loby/Ground/Part5").gameObject.SetActive (true);
				other.gameObject.SetActive (false);
			}
			if (other.name == "trigger6") {
				mission5.transform.Find ("Building/Loby/Ground/Part1/ground1").gameObject.GetComponent<MeshRenderer> ().enabled = true;
				mission5.transform.Find ("Building/Loby/Ground/Part2/ground3").gameObject.GetComponent<MeshRenderer> ().enabled = true;
				mission5.transform.Find ("Building/Loby/Ground/Part3/ground5").gameObject.GetComponent<MeshRenderer> ().enabled = true;
				mission5.transform.Find ("Building/Loby/Ground/Part4/ground7").gameObject.GetComponent<MeshRenderer> ().enabled = true;
				mission5.transform.Find ("Building/Loby/Ground/Part5/ground9").gameObject.GetComponent<MeshRenderer> ().enabled = true;
				mission5.transform.Find ("Building/Loby/Ground/Part5/ground10").gameObject.GetComponent<MeshRenderer> ().enabled = true;
			}
			if (other.name == "trigger7") {
				other.gameObject.SetActive (false);
				float angle = mission5.transform.eulerAngles.y;
				float arc = 2f * Mathf.PI * angle / 360f;
				mission6.transform.position = mission5.transform.position + new Vector3 (47.5f*Mathf.Cos(arc)-52.5f*Mathf.Sin(arc), 0f, -52.5f*Mathf.Cos(arc)-47.5f*Mathf.Sin(arc));
				mission6.transform.rotation = Quaternion.Euler( 0f, angle-90f, 0f );
				mission6.gameObject.SetActive (true);
			}
		}
	}
}
