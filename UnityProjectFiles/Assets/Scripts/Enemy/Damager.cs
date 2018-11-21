using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damager : MonoBehaviour {
	public int dmg;
	void OnCollisionEnter2D(Collision2D collision) {
		var hit = collision.gameObject;
		if (hit.tag == "Player") {
			var life = hit.GetComponent<PlayerInfo>();
			life.TakeDmg(dmg);
			// hit.GetComponent<Rigidbody2D>().AddForce((hit.transform.position - transform.position) * 20.0f, ForceMode2D.Impulse);
			//Find a way to inflict dmg periodically
			//Correct the enemy collision and related behaviour with the player
		}
	}
}
