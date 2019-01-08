﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.FirstPerson;

public class GameControl : MonoBehaviour {

	public GameObject mainScreen;
	public GameObject cameraMenu;
	public GameObject FPSControl;
	public GameObject center;
	public GameObject menu;
	public GameObject mission0;

	private bool mainscreen = true;
	private bool menuscreen = false;
	private int count = 0;

	void Update(){
		if (count == 0) {
			if (Input.GetKey (KeyCode.Escape) && !menuscreen && !mainscreen) {
				menu.gameObject.SetActive (true);
				menuscreen = true;
				pauseGame ();
				count = 30;
			} else if (Input.GetKey (KeyCode.Escape) && menuscreen && !mainscreen) {
				continueGame ();
				count = 30;
			}
		} else {
			count = count - 1;
		}
	}

	public void start(){
		mainScreen.gameObject.SetActive (false);
		cameraMenu.gameObject.SetActive (false);
		FPSControl.gameObject.SetActive (true);
		center.gameObject.SetActive (true);
		mainscreen = false;
		mission0.gameObject.SetActive (true);
	}

	public void exit(){
		Application.Quit ();
	}

	public void continueGame(){
		menu.gameObject.SetActive (false);
		FPSControl.GetComponent<FirstPersonController> ().enabled = true;
		menuscreen = false;
		Time.timeScale = 1;
		Cursor.visible = false;
		Cursor.lockState = CursorLockMode.Locked;
	}
	
	public void pauseGame(){
		FPSControl.GetComponent<FirstPersonController> ().enabled = false;
		Time.timeScale = 0;
		Cursor.visible = true;
		Cursor.lockState = CursorLockMode.None;
	}

	public void restartGame(){
		SceneManager.LoadScene ("miniChamber");
		Time.timeScale = 1;
		Cursor.visible = true;
		Cursor.lockState = CursorLockMode.None;
	}

}
