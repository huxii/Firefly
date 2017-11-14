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

		// speed 
		float speed = Random.Range(0.02f, 0.05f);

		animator.SetFloat("Direction", dir);
		animator.speed = speed;

		animator.Play("Shake", 0, pro);
	}

	// Update is called once per frame
	void Update()
	{
		if (dir == 1.0f)
		{
			if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.99f)
			{
				animator.Play("Shake", 0, 0.0f);
			}
		}
		else
		{
			if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime <= 0.01f)
			{
				animator.Play("Shake", 0, 1.0f);
			}			
		}
	}

	void OnTriggerEnter(Collider target)
	{
		if (target.gameObject.tag == "Player")
		{
			// speed 
			float speed = Random.Range(0.5f, 0.6f);
			animator.speed = speed;

			Debug.Log("enter");
		}
	}
}
