using UnityEngine;

namespace Environement
{
	public class UpdateSunColor : MonoBehaviour
	{
		[SerializeField] private Color _newColor;
		[SerializeField] private float _newIntensity = 1f;
		
		private void OnTriggerEnter2D(Collider2D other)
		{
			SunControl.Instance.ChangeColor(_newColor, _newIntensity);
		}
	}
}
