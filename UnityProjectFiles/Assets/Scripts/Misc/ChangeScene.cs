using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class ChangeScene : MonoBehaviour {
	// Use this for initialization
	public void SwitchScene(string sceneName) {
		Time.timeScale = 1f;
		SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
	}

	public void ChangeSettingsTab(GameObject SettingsTab) {
		SettingsTab.SetActive(!SettingsTab.activeSelf);
	}

	public void QuitGame() {
		Application.Quit();
	}
}
