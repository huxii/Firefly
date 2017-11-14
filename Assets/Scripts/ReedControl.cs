using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReedControl : MonoBehaviour
{
	Animator animator;

	float dir;

	// Use this for initialization
	void Start()
	{
		animator = GetComponent<Animator>();

		// start point
		int tmp = (int)Random.Range(0, 1.99999f);
		float pro = 0.5f - tmp * 0.5f;

		// direction
		tmp = (int)Random.Range(0, 1.99999f);
		dir = 1.0f;
		if (tmp == 0)
		{
			dir = -1.0f;
		}

		animator.SetFloat("Direction", dir);
		animator.speed = 0;

		animator.Play("Shake", 0, pro);
	}

	// Update is called once per frame
	void Update()
	{
	}

	void OnTriggerEnter(Collider target)
	{
		if (target.gameObject.tag == "Player")
		{
			// speed 
			float speed = Random.Range(0.8f, 1.2f);
			animator.speed = speed;

			Debug.Log("enter");
		}
	}
}
