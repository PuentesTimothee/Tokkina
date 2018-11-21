using System.Collections.Generic;
using UnityEngine;

namespace Environement
{
	public class MovingPlateform : MonoBehaviour
	{
		public Transform Plateform;
		public List<Transform> PassagesPoints;
		[Range(0f, 100f)] public float Speed = 1f;
		
		private int _actualPassagePoint = 0;
		
		private Transform _from;
		private Transform _to;
		
		private void Awake()
		{
			if (Plateform == null)
			{
				Debug.LogError("No 'Plateform' child for this moving Plateform");
				enabled = false;
			}
			NextPassagePoint();
		}

		private void FixedUpdate()
		{
			Vector3 direction = (_to.position - Plateform.position);
			float actualSpeed = Speed * Time.deltaTime;
			
			if (direction.magnitude < actualSpeed)
				NextPassagePoint();
			else
				Plateform.position += direction.normalized * actualSpeed;
		}
		
		private void NextPassagePoint()	
		{
			Plateform.position = PassagesPoints[_actualPassagePoint].position;
			_from = PassagesPoints[_actualPassagePoint];
			_actualPassagePoint = (_actualPassagePoint + 1) % PassagesPoints.Count;
			_to = PassagesPoints[_actualPassagePoint];
		}

		private void OnDrawGizmos()
		{
			var tmp = Plateform.GetComponent<BoxCollider2D>().size;
			Vector3 size = new Vector3(tmp.x, tmp.y, 1);
			Transform prev = null;
			foreach (var passagePoint in PassagesPoints)
			{
				if (prev != null)
				{
					Gizmos.color = new Color(1, 0.5f, 0, 0.75f);
					Gizmos.DrawLine(prev.position, passagePoint.position);
				}
				Gizmos.color = new Color(1, 0, 0, 0.75f);
				Gizmos.DrawCube(passagePoint.position, size);
				prev = passagePoint;
			}
		}
	}
}
