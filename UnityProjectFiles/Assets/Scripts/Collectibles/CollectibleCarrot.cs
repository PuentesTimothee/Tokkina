using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleCarrot : MonoBehaviour {
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.CompareTag("Player")) {
			other.gameObject.GetComponent<PlayerInfo>().addCarrot();
			Destroy(this.gameObject);
		}
	}
}
