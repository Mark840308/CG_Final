using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mission4 : MonoBehaviour {

	public GameObject mission4;
	public GameObject start;

	void OnTriggerEnter(Collider other){
		if (other.gameObject.CompareTag ("mission4trigger")) {
			if (other.name == "Lava") {
				other.transform.position = other.transform.position + new Vector3 (0f, 2f, 0f);
			}
			if (other.name == "trigger1") {
				Vector3 displacement = other.transform.position - mission4.transform.Find ("Building/Lava").gameObject.transform.position;

				GameObject FPS = GameObject.Find ("FirstPersonCharacter").gameObject;
				GameObject Well = mission4.transform.Find ("Building/Well").gameObject;
				if (FPS.transform.eulerAngles.x >= 270f && FPS.transform.eulerAngles.x < 320f) {
					start.transform.position = mission4.transform.position + new Vector3 (0f, -270f, 0f);
					start.transform.rotation = mission4.transform.rotation;
					start.gameObject.SetActive (true);
					Well.transform.position = mission4.transform.position + new Vector3 (0f, -85.5f, 0f);
					Well.transform.localScale = new Vector3 (1f, 169f, 1f);
					other.gameObject.SetActive (false);
				} else {
					transform.position = transform.position - displacement * 0.7f;
				}
			}
		}
	}
	
}
