using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleCherry : MonoBehaviour
{
	[SerializeField] private GameObject _pickupParticle;
	
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.CompareTag("Player")) {
			other.gameObject.GetComponent<PlayerInfo>().addCherry();
			if (_pickupParticle != null)
			{
				var go = Instantiate(_pickupParticle);
				go.transform.position = transform.position;
			}
			Destroy(this.gameObject);
		}
	}
}
