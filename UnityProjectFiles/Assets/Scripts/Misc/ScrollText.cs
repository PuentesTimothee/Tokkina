using UnityEngine;
using UnityEngine.UI;
using System.Collections;
public class ScrollText : MonoBehaviour {
	public float scrollSpeed = 80;
	private bool scroll = false;
	public GameObject button;

	void Start() {
		StartCoroutine(StartScroll());
	}
	void Update () {
		if (scroll) {
			Vector3 pos = transform.position;
			Vector3 localVectorUp = transform.TransformDirection(0,1,0);
			pos += localVectorUp * scrollSpeed * Time.deltaTime;
			transform.position = pos;
			float bottom = GetComponent<RectTransform>().offsetMin.y;
			if (bottom >= 0) {
				scroll = false;
				StartCoroutine(DisplayText());
			}
		}
	}

	IEnumerator StartScroll() {
		yield return new WaitForSeconds(2);
		scroll = true;
	}

	IEnumerator DisplayText() {
		yield return new WaitForSeconds(2);
		button.SetActive(true);
	}
}

