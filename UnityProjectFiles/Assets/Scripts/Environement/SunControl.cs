using System.Collections;
using UnityEngine;

namespace Environement
{
	[RequireComponent(typeof(Light))]
	public class SunControl : MonoBehaviour
	{
		public static SunControl Instance;
		[SerializeField] private Light _subLight;
		private Light _light;
	
		private void Awake()
		{
			Instance = this;
			_light = GetComponent<Light>();
		}

		public void ChangeColor(Color color, float intensity)
		{
			StopCoroutine("Coroutine_ChangeColor");
			StartCoroutine(Coroutine_ChangeColor(color, intensity));
		}

		private readonly float Length = 1f;
		private IEnumerator Coroutine_ChangeColor(Color nextColor, float nextIntensity)
		{
			float timer = 0f;

			if (nextColor == _light.color && nextIntensity == _light.intensity)
				yield break;
			
			var prevColor = _light.color;
			var prevIntensity = _light.intensity;
	
			while (timer < Length)
			{
				_light.color = Color.Lerp(prevColor, nextColor, timer / Length);
				_light.intensity = Mathf.Lerp(prevIntensity, nextIntensity, timer / Length);
				if (_subLight != null)
					_subLight.intensity = 1 - _light.intensity;
				timer += Time.deltaTime;
				yield return null;
			}
			
			_light.color = nextColor;
			_light.intensity = nextIntensity;
			if (_subLight != null)
				_subLight.intensity = 1 - _light.intensity;
		}
	}
}
