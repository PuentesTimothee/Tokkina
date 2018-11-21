using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MenuInteraction : MonoBehaviour {
	public Text text;

	public void OnPointerEnter() {
		text.color = new Color(0.69f, 0.91f, 0f);
	}

	public void OnPointerExit() {
		text.color = new Color(0.58f, 0.78f, 0);
	}

	public void OnPointerDown() {
        text.color = new Color(0.21f, 0.29f, 0);
    }

	public void OnPointerUp() {
        text.color = new Color(0.58f, 0.78f, 0);
    }
}
