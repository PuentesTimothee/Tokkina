using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BabyMove : MonoBehaviour {
	public float speed;
	private Rigidbody2D _rb;

	void Start()
	{
		_rb = GetComponent<Rigidbody2D>();
	}

	public void FixedUpdate()
	{
		int rand = Random.Range(1, 500);
		if (rand <= 5) {
			Vector3 Scale = transform.localScale;
			Scale.x *= -1;
			transform.localScale = Scale;
			speed *= -1;
		}
		_rb.velocity = new Vector2(speed, 0);
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("OneWayHitbox")) {
			Vector3 Scale = transform.localScale;
			Scale.x *= -1;
			transform.localScale = Scale;
			speed *= -1;
		}
	}
}
