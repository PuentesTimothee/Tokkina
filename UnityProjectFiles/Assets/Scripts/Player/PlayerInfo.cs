using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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

	public Image LifeTile;
	public Text Score;
	public Text Carrots;
	private Animator anim;

	public float spriteBlinkingTimer = 0.0f;
	public float spriteBlinkingMiniDuration = 0.1f;
	public float spriteBlinkingTotalTimer = 0.0f;
	public float spriteBlinkingTotalDuration = 1.0f;
	public bool startBlinking = false;

	private AudioSource soundSource;
	public AudioSource musicSource;
	public AudioClip clip;
	public AudioClip hurtSound;
	public AudioClip carrotSound;
	public AudioClip heartSound;
	public AudioClip diamondSound;
	public AudioClip cherrySound;


	void Start () {
		anim = GetComponent<Animator>();
		soundSource = GetComponent<AudioSource>();
		life = maxLife;
		updateScore();
		updateCarrot();
	}

	void Update() {
		if(startBlinking == true)
		{
			SpriteBlinkingEffect();
		}
	}

	public int GetLife() {
		return life;
	}

	public void GiveLife(int hp) {
		soundSource.PlayOneShot(heartSound);
		life += hp;
		if (life > maxLife)
			life = maxLife;
		ChangeLifeDisplay();
	}

	public void TakeDmg(int dmg)
	{
		if (startBlinking == true)
			return;
		life -= dmg;
		soundSource.PlayOneShot(hurtSound);
		if (life <= 0)
		{
			life = 0;
			ChangeLifeDisplay();
			DieAndRespawn();
			return;
		}
		ChangeLifeDisplay();
		startBlinking = true;

	}

	public void DieAndRespawn()
	{
		musicSource.Stop();
		anim.SetTrigger("Death");
		musicSource.clip = clip;
		musicSource.loop = false;
		musicSource.Play();
		StartCoroutine(GameLost());
	}

	IEnumerator GameLost() {
		yield return new WaitForSeconds(5F);
		SceneManager.LoadScene("LosingScreen", LoadSceneMode.Single);
	}

	public void addCarrot() {
		++nbCarrots;
		PlayerScore.pts += (int)OBJPoints.CARROT;
		updateScore();
		updateCarrot();
		soundSource.PlayOneShot(carrotSound);
	}

	public void addCherry() {
		++PlayerScore.nbCherries;
		PlayerScore.pts += (int)OBJPoints.CHERRY;
		updateScore();
		updateCarrot();
		soundSource.PlayOneShot(cherrySound);
	}

	public void addDiamond() {
		++PlayerScore.nbDiamonds;
		PlayerScore.pts += (int)OBJPoints.DIAMOND;
		updateScore();
		updateCarrot();
		soundSource.PlayOneShot(diamondSound);
	}

	public void updateScore() {
		Score.text = "Score: " + PlayerScore.pts.ToString();
	}

	public void updateCarrot() {
		if (isDone())
			Carrots.text = "You got all the carrots!\nYou can go back home";
		else
			Carrots.text = nbCarrots.ToString() + " / " + requiredCarrots.ToString();
	}

	public void ChangeLifeDisplay() {
		LifeTile.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 300 * life);
	}

	public bool isDone() {
		return nbCarrots >= requiredCarrots;
	}

	private void SpriteBlinkingEffect()
	{
		spriteBlinkingTotalTimer += Time.deltaTime;
		if(spriteBlinkingTotalTimer >= spriteBlinkingTotalDuration)
		{
			startBlinking = false;
			spriteBlinkingTotalTimer = 0.0f;
			this.gameObject.GetComponent<SpriteRenderer> ().enabled = true;   // according to
			//your sprite
			return;
		}

		spriteBlinkingTimer += Time.deltaTime;
		if(spriteBlinkingTimer >= spriteBlinkingMiniDuration)
		{
			spriteBlinkingTimer = 0.0f;
			if (this.gameObject.GetComponent<SpriteRenderer> ().enabled == true) {
				this.gameObject.GetComponent<SpriteRenderer> ().enabled = false;  //make changes
			} else {
				this.gameObject.GetComponent<SpriteRenderer> ().enabled = true;   //make changes
			}
		}
	}
}
