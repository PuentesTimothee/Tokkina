using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitCredits : MonoBehaviour {

	private ChangeScene change;

	// Use this for initialization
	void Start () {
		change = GetComponent<ChangeScene>();
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.Escape))
			change.SwitchScene("MainMenu");
	}
}
