using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mission10 : MonoBehaviour {

	public GameObject mission10;

	private int MaxTime = 1500;
	private int WaitTime = 0;
	private int RotateAngle = 360; // 90degree*4
	private int count = 0;
	private bool disappear = true;
	private bool end = false;
	private int endCountEnd = 6000; // 300grid/0.2

	private int back = 30;

	void FixedUpdate(){
		WaitTime = WaitTime + 1;
		count = count + 1;
		if (WaitTime >= MaxTime && RotateAngle != 0) {
			Change ();
			if (disappear) {
				Disappear ();
				disappear = false;
			}
			if (RotateAngle == 0) {
				Appear ();
			}
		}
		if (count == 50) {
			WarningOn ();
			count = 0;
		}
		if (count >= 10000) {
			count = 51;
		}

		if (end) {
			endCountEnd = endCountEnd - 1;
			EnddingMove ();
		}
		if (endCountEnd == 0) {
			end = false;
		}
		if (back <= 15) {
			WarningMusicOff ();
		}
		if (1 < back && back <= 8) {
			NervousMusicOn ();
		}
	}

	void Change(){
		mission10.transform.Find ("Building/Loby/Wall1").transform.Rotate (0f, 0f, -0.25f);
		mission10.transform.Find ("Building/Loby/Wall2").transform.Rotate (0f, 0f, -0.25f);
		mission10.transform.Find ("Building/Loby/Wall3").transform.Rotate (0f, 0f, -0.25f);
		mission10.transform.Find ("Building/Loby/Wall4").transform.Rotate (0f, 0f, -0.25f);
		mission10.transform.Find ("Building/Loby/Wall5").gameObject.SetActive (false);
		mission10.transform.Find ("Building/Block").gameObject.SetActive (true);
		RotateAngle = RotateAngle - 1;
	}

	void Disappear(){
		WarningOff ();
		count = 51;
		mission10.transform.Find ("Building/Loby/worldChange").GetComponent<AudioSource> ().Play ();
		mission10.transform.Find("Building/nervousMusic").gameObject.SetActive(false);
	}

	void Appear(){
		mission10.transform.Find ("Building/Illustration1").gameObject.SetActive (true);
		mission10.transform.Find ("Building/Illustration2").gameObject.SetActive (true);
		mission10.transform.Find ("Building/Loby/worldChange").GetComponent<AudioSource> ().Stop ();
		mission10.transform.Find ("Building/Road").gameObject.SetActive (true);
	}
	
	void WarningOff(){
		mission10.transform.Find ("Building/Warning").gameObject.SetActive (false);
	}

	void WarningOn(){
		back = back - 1;
		mission10.transform.Find ("Building/Warning/warning2/images").gameObject.GetComponent<MeshRenderer>().material = Resources.Load("Back/Materials/"+back.ToString(), typeof(Material)) as Material;
	}

	void EnddingMove(){
		mission10.transform.Find ("Ending").transform.position = mission10.transform.Find ("Ending").transform.position + new Vector3 (0f, 0.1f, 0f);
		if (mission10.transform.Find ("Ending").transform.position.y >= 80) {
			end = false;
		}
	}

	void WarningMusicOff(){
		mission10.transform.Find ("Building/warningMusic").gameObject.SetActive (false);
	}

	void NervousMusicOn(){
		mission10.transform.Find ("Building/nervousMusic").gameObject.SetActive (true);
	}

	void NervousMusicOff(){
		mission10.transform.Find ("Building/nervousMusic").gameObject.SetActive (false);
	}

	void OnTriggerEnter(Collider other){
		if (other.gameObject.CompareTag ("mission10trigger")) {
			if (other.transform.name == "trigger1") {
				mission10.transform.Find ("Ending").gameObject.SetActive (true);
				end = true;
				other.gameObject.SetActive (false);
				transform.Find ("backgroundMusic3").gameObject.SetActive (true);
			}
		}
	}
}
