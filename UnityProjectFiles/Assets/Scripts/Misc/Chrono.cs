using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Chrono : MonoBehaviour {
	public float timeInSeconds;
	public Text timer;
	public TextAlignment clock;
	private float endTime;
	// Use this for initialization
	void Start () {
		endTime = Time.time + timeInSeconds;
	}
	
	// Update is called once per frame
	void Update () {
		float timeRemaining = endTime - Time.time;
		string minutes = ((int)(timeRemaining / 60)).ToString();
		string seconds = ((int)(timeRemaining % 60)).ToString();
		timer.text = minutes + ':' + seconds;
	}
}
