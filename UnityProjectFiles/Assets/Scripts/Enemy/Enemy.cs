using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Animator anim;
    private MoveInterface move;

    void Start()
    {
        anim = GetComponent<Animator>();
        move = GetComponent<MoveInterface>();
    }

	void FixedUpdate()
	{
        move.MoveToWayPoint();

        anim.speed = Mathf.Abs(move.GetSpeed()) * Time.deltaTime;
	}
}
