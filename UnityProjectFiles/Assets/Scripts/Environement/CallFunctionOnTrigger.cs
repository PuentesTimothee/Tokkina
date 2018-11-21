using UnityEngine;
using UnityEngine.Events;

namespace Environement
{
	[RequireComponent(typeof(Collider2D))]
	public class CallFunctionOnTrigger : MonoBehaviour
	{
		public UnityEvent OnEnter;
		public UnityEvent OnExit;

		private void Start()
		{
			if (OnEnter == null)
				OnEnter = new UnityEvent();
			if (OnExit == null)
				OnExit = new UnityEvent();
		}
		
		private void OnTriggerEnter2D(Collider2D other)
		{
			OnEnter.Invoke();
		}

		private void OnTriggerExit2D(Collider2D other)
		{
			OnExit.Invoke();
		}
	}
}
