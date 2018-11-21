using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInfo : MonoBehaviour {
	private enum OBJPoints {
		OTHER = 10,
		CHERRY = 100,
		DIAMOND = 500,
		CARROT = 1000
	};
	public int maxLife;
	private int life;
	private int nbCarrots;
	public int requiredCarrots;

	public Text Score;
	public Text Carrots;

	void Start () {
		life = maxLife;
		updateScore();
		updateCarrot();
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

	public void addCarrot() {
		++nbCarrots;
		PlayerScore.pts += (int)OBJPoints.CARROT;
		updateScore();
		updateCarrot();
	}

	public void addCherry() {
		++PlayerScore.nbCherries;
		PlayerScore.pts += (int)OBJPoints.CHERRY;
		updateScore();
		updateCarrot();
	}

	public void addDiamond() {
		++PlayerScore.nbDiamonds;
		PlayerScore.pts += (int)OBJPoints.DIAMOND;
		updateScore();
		updateCarrot();
	}

	public void updateScore() {
		Score.text = "Score: " + PlayerScore.pts.ToString();
	}

	public void updateCarrot() {
		Carrots.text = nbCarrots.ToString() + " / " + requiredCarrots.ToString();
	}

	public bool isDone() {
		return nbCarrots >= requiredCarrots;
	}
}
