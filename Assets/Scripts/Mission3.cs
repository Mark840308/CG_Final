using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mission3 : MonoBehaviour {

	public GameObject mission3;
	public GameObject mission4;

	private float angle;

	void FixedUpdate(){
		angle = transform.eulerAngles.y;
	}

	void OnTriggerEnter(Collider other){
		float angleM = mission3.transform.eulerAngles.y;
		if (angleM > 180) {
			angleM = angleM - 360;
		}
		if (other.gameObject.CompareTag ("mission3trigger")) {
			if (other.name == "trigger1") {
				other.gameObject.SetActive (false);
				mission3.transform.Find ("Trigger/trigger2").gameObject.SetActive (true);
				mission3.transform.Find ("Discourse/discourse1").gameObject.SetActive (true);
				mission4.transform.position = mission3.transform.position + new Vector3 (60f * Mathf.Sin (2f * Mathf.PI * angleM / 360f), 0f, 60f * Mathf.Cos (2f * Mathf.PI * angleM / 360f));
				mission4.transform.rotation = Quaternion.Euler( 0f, angleM+90f, 0f );
				mission4.gameObject.SetActive (true);
			}
			if (other.name == "trigger2") {
				other.gameObject.SetActive (false);
				mission3.transform.Find ("Discourse/discourse2").gameObject.SetActive (true);
			}
			if (other.name == "trigger3") {
				float angleW = mission3.transform.Find ("Building/Wall/wall").transform.eulerAngles.x;
				if (angle%360 >= 135f+angleM && angle%360 <= 225f+angleM && (int)angleW == 270) {
					mission3.transform.Find ("Building/Wall/wall").transform.localRotation = Quaternion.Euler (90f, 0f, 0.0f);
				}
				float lb = (315f + angleM) % 360f;
				float ub = (45f+angleM)%360f;
				if (lb>ub){
					if ((angle%360 >= lb || angle%360 <= ub) && (int)angleW == 90) {
						mission3.transform.Find ("Building/Wall/wall").transform.localRotation = Quaternion.Euler (-90f, 0f, 0.0f);
					}
				}
				else {
					if ((angle%360 >= lb && angle%360 <= ub) && (int)angleW == 90) {
						mission3.transform.Find ("Building/Wall/wall").transform.localRotation = Quaternion.Euler (-90f, 0f, 0.0f);
					}
				}
			}
		}
	}
}
