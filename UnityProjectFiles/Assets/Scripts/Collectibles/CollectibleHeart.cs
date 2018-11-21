using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleHeart : MonoBehaviour
{
	[SerializeField] private GameObject _pickupParticle;
	
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.CompareTag("Player")) {
			PlayerInfo player = other.gameObject.GetComponent<PlayerInfo>();
			if (player.GetLife() == player.maxLife)
				return ;
			player.GiveLife(1);
			if (_pickupParticle != null)
			{
				var go = Instantiate(_pickupParticle);
				go.transform.position = transform.position;
			}
			Destroy(this.gameObject);
		}
	}
}
