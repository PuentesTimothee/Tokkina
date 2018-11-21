using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetScore : MonoBehaviour {
	public void Reset() {
		PlayerScore.pts = PlayerScore.savedPts;
	}

	public void HardReset() {
		PlayerScore.pts = 0;
	}

	public void SaveScore() {
		PlayerScore.savedPts = PlayerScore.pts;
	}
}
