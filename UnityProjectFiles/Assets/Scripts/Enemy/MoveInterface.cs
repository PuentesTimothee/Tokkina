using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class MoveInterface : MonoBehaviour
{
	public float speed;
    private bool going = true;
    public Transform WayPoint;
    private float OriginX;
    private Vector2 direction;
	private Rigidbody2D _rb;

	void Start()
	{
		_rb = GetComponent<Rigidbody2D>();
		OriginX = transform.position.x;

        direction = transform.position - WayPoint.position;
        if (direction.y < 2 && direction.y > -2)
            direction.y = 0;

        //We're doing this because the sprite is primarly facing left
        if (direction.x > 0)
            speed *= (speed < 0) ? 1 : -1;
        else if (direction.x < 0)
        {
            speed *= speed > 0 ? 1 : -1;
            Flip();
        }
	}

	public void MoveToWayPoint()
	{
		_rb.velocity = new Vector2(speed * Time.deltaTime, 0);

        if (direction.x > 0)
        {
            if ((WayPoint.position.x >= transform.position.x && going)
                || (OriginX <= transform.position.x && !going))
                ChangeDirection();
        }
        else if (direction.x < 0)
        {
            if ((WayPoint.position.x <= transform.position.x && going)
                || (OriginX >= transform.position.x && !going))
                ChangeDirection();
        }
	}

	public void ChangeDirection()
    {
        going = !going;
        speed *= -1;
        Flip();
    }

    void Flip()
    {
        Vector3 Scale = transform.localScale;
        Scale.x *= -1;
        transform.localScale = Scale;
    }

	public float GetSpeed()
	{
		return speed;
	}
}
