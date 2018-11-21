using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;


public class EndingTrigger : MonoBehaviour {
	public bool end = false;
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.CompareTag("Player")) {
			var player = other.gameObject.GetComponent<PlayerInfo>();
			if (tag == "DeathCollider")
				player.TakeDmg(player.maxLife);
			else if (player.isDone()) {
				PlayerPrefs.SetInt("Ending", end ? 1 : 0);
				SceneManager.LoadScene("EndingScreen", LoadSceneMode.Single);
			}
		}
	}

	private void OnDrawGizmos()
	{
		var tmp = GetComponent<BoxCollider2D>().size;
		Gizmos.color = new Color(1, 0, 0.5f, 0.75f);
		Gizmos.DrawCube(transform.position, tmp);
	}
}
