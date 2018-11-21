using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life : MonoBehaviour {
	public int maxLife;
	private int life;
	// Use this for initialization
	void Start () {
		life = maxLife;
	}

	public void GiveLife(int hp) {
		life += hp;
		if (life > maxLife)
			life = maxLife;
	}

	public void TakeDmg(int dmg) {
		life -= dmg;
		if (life < 0)
			life = 0;
	}
}
