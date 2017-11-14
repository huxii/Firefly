using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorGradientControl : MonoBehaviour
{
	[SerializeField]
	Gradient gradient;
	[SerializeField]

	public Material mat;
	public float duration = 2.0f;

	float t;
	bool start;

	void Start()
	{
		t = 0.0f;
		start = false;
		mat.SetColor("_TintColor", gradient.Evaluate(0));
	}

	void Update()
	{
		if (start)
		{
			float value = Mathf.Lerp(0f, 1f, t);
			t += Time.deltaTime / duration;
			Color color = gradient.Evaluate(value);

			mat.SetColor("_TintColor", color);
		}
	}

	void OnTriggerEnter(Collider target)
	{
		start = true;
	}
}

