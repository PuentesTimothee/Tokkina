using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextScore : MonoBehaviour {
	private Text score;
	public GameObject ret;
	public AudioSource audioSource;
	public AudioClip scoreSound;
	// Use this for initialization
	void Start () {
		score = GetComponent<Text>();
		StartCoroutine(Display());
	}

	IEnumerator Display() {
		yield return new WaitForSeconds(3);
		score.text = "Score:\n";
		yield return new WaitForSeconds(1);
		score.text = "Score:\n" + PlayerScore.pts.ToString();
		audioSource.PlayOneShot(scoreSound);
		StartCoroutine(Return());
	}

	IEnumerator Return() {
		yield return new WaitForSeconds(1);
		ret.SetActive(true);
	}
}
