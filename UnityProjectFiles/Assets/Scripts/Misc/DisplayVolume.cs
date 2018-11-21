using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayVolume : MonoBehaviour {
	public Slider slider;
	private Text text;
	// Use this for initialization
	void Start () {
		text = GetComponent<Text>();
		slider.value = Volume.music;
		ShowSliderValue();
	}
	
	public void ShowSliderValue () {
		Volume.music = (int)slider.value;
		text.text = slider.value.ToString();
	}
}
