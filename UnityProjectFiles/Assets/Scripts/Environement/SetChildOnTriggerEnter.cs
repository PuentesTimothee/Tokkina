using UnityEngine;

namespace Environement
{
	public class SetChildOnTriggerEnter : MonoBehaviour
	{
		private Transform _obj;
		private Transform _lastParent;
		
		private void OnTriggerEnter2D(Collider2D other)
		{
			if (other.CompareTag("Player"))
			{
				_obj = other.transform;
				_lastParent = _obj.parent;
				_obj.parent = transform;
			}
		}

		private void OnTriggerExit2D(Collider2D other)
		{
			if (other.transform == _obj)
			{
				_obj.parent = _lastParent;
				_lastParent = null;
				_obj = null;
			}
		}
	}
}
