using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mission1 : MonoBehaviour {

	public GameObject mission1;
	public GameObject mission2;

	void OnTriggerEnter(Collider other){
		if (other.gameObject.CompareTag ("mission1trigger")) {
			if (other.name == "trigger1") {
				other.gameObject.SetActive (false);
				mission1.transform.Find("Trigger/trigger2").gameObject.SetActive(false);
				mission1.transform.Find ("Building/Wall2").gameObject.SetActive (false);
				mission1.transform.Find ("Building/stop2").gameObject.SetActive (false);
				mission1.transform.Find ("Discourse/discourse2").gameObject.SetActive (true);
				mission1.transform.Find ("Discourse/discourse2").gameObject.transform.position = new Vector3 (-5f, 1.5f, 65.01f);
				mission2.transform.position = mission1.transform.position + new Vector3( -39.5f, 0f, 66.5f );
				mission2.transform.rotation = Quaternion.Euler( 0f, 90f, 0f );
				mission2.gameObject.SetActive(true);
			}
			if (other.name == "trigger2") {
				other.gameObject.SetActive (false);
				mission1.transform.Find("Trigger/trigger1").gameObject.SetActive(false);
				mission1.transform.Find ("Building/Wall1").gameObject.SetActive (false);
				mission1.transform.Find ("Building/stop1").gameObject.SetActive (false);
				mission1.transform.Find ("Discourse/discourse2").gameObject.SetActive (true);
				mission1.transform.Find ("Discourse/discourse2").gameObject.transform.position = new Vector3 (5f, 1.5f, 65.01f);
				mission2.transform.position = mission1.transform.position + new Vector3( 39.5f, 0f, 66.5f );
				mission2.transform.rotation = Quaternion.Euler( 0f, -90f, 0f );
				mission2.gameObject.SetActive(true);
			}
		}
	}

}
