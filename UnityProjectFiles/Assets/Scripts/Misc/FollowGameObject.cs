using UnityEngine;

public class FollowGameObject : MonoBehaviour
{
	public Transform Target;
	public Vector3 DistanceFromObject = new Vector3(0, 0, -10f);
	
	private void Awake()
	{
		if (Target != null)
			SetTarget(Target);
	}
	
	public void SetTarget(Transform target)
	{
		Target = target;
	}
	
	private void FixedUpdate()
	{
		if (Target != null)
		{
			var newPos = Target.position + DistanceFromObject;
			transform.position = newPos;
		}
	}
}
