using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class ChangeVolume : MonoBehaviour {
	private AudioSource music;
	// Use this for initialization
	void Start () {
		music = GetComponent<AudioSource>();
		ChangeMusicVolume();
	}

	public void ChangeMusicVolume() {
		music.volume = Volume.music * 0.01f;
	}
}
