using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextLose : MonoBehaviour {
	public GameObject Lose;
	// Use this for initialization
	void Start () {
		StartCoroutine(Display());
	}

	IEnumerator Display() {
		yield return new WaitForSeconds(1);
		Lose.SetActive(true);
	}
}
