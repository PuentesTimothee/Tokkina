using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChangeContinueButton : MonoBehaviour {
	private bool end;
	public Text text;
	public GameObject Forest;
	public GameObject Beach;
	// Use this for initialization
	void Awake() {
		int res = PlayerPrefs.GetInt("Ending");
		end = res == 1 ? true : false;
		Forest.SetActive(!end);
		Beach.SetActive(end);
	}

	void Start() {
		text.text = end ? "End your adventure" : "Continue";
	}

	public void ChangeSceneAtEnding()
	{
		SceneManager.LoadScene(end ? "Credits" : "Level Hills", LoadSceneMode.Single);
	}
}
