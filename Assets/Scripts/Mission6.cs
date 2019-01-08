using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mission6 : MonoBehaviour {

	public GameObject mission5;
	public GameObject mission6;
	public GameObject mission7;

	void OnTriggerEnter(Collider other){
		if (other.gameObject.CompareTag ("mission6trigger")) {
			if (other.name == "trigger1") {
				other.gameObject.SetActive (false);
				mission5.transform.Find ("Discourse/discourse3").gameObject.SetActive (true);
				mission6.transform.Find ("Trigger/trigger2").gameObject.SetActive (true);
				Vector3 angle = 2f*Mathf.PI*mission6.transform.eulerAngles/360f;
				mission7.transform.position = mission6.transform.position + new Vector3 (-11.5f*Mathf.Sin(angle.y), 6f, -11.5f*Mathf.Cos(angle.y)) ;
				mission7.transform.rotation = mission6.transform.rotation;
				mission7.gameObject.SetActive (true);
			}
			if (other.name == "trigger2") {
				other.gameObject.SetActive (false);
				mission6.transform.Find ("Building/Obstacle").gameObject.SetActive (false);
			}
		}


	}

}
