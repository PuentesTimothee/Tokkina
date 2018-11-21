using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CinematicExperience : MonoBehaviour {
    private MoveInterface move;

    void Start()
    {
        move = GetComponent<MoveInterface>();
    }
	
	// Update is called once per frame
	void Update() {
		int rand = Random.Range(1, 200);
		if (rand <= 1)
			move.ChangeDirection();
	}
}
