using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassControl : MonoBehaviour 
{
	Animator animator;

	// Use this for initialization
	void Start()
	{
		animator = GetComponent<Animator>();

		// start point
		int tmp = (int)Random.Range(0, 1.99999f);
		float pro = 0.5f - tmp * 0.5f;

		// direction
		tmp = (int)Random.Range(0, 1.99999f);
		float dir = 1.0f;
		if (tmp == 0)
		{
			dir = -1.0f;
		}

		// speed 
		float speed = Random.Range(0.5f, 0.6f);

		animator.SetFloat("Direction", dir);
		animator.speed = speed;

		animator.Play("Shake", 0, pro);

		Debug.Log(dir);
	}

	// Update is called once per frame
	void Update()
	{

	}
}
