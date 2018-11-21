using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandlePopups : MonoBehaviour {
	public GameObject PauseMenu;
	public GameObject Tip;
	public GameObject UI;
	private bool isPaused = false;
	private bool dispTip = true;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Tip && dispTip && !isPaused) {
			Tip.SetActive(true);
			if (Input.GetKey(KeyCode.X)) {
				Tip.SetActive(false);
				dispTip = false;
			}
		}
		if (Input.GetKeyUp(KeyCode.Escape)) {
			if (!isPaused)
				Pause();
			else
				Resume();
		}
	}

	public void Pause() {
		isPaused = true;
		PauseMenu.SetActive(true);
		if (Tip && dispTip)
			Tip.SetActive(false);
		UI.SetActive(false);			
		Time.timeScale = 0f;
	}

	public void Resume() {
		isPaused = false;
		PauseMenu.SetActive(false);
		if (Tip && dispTip)
			Tip.SetActive(true);
		UI.SetActive(true);				
		Time.timeScale = 1f;
	}
}
