using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireflyControl : MonoBehaviour
{
	GameObject gameManager;
	Animator animator;

	bool lit;

	// Use this for initialization
	void Start()
	{
		gameManager = GameObject.Find("GameManager");
		animator = GetComponent<Animator>();
		lit = false;
	}

	// Update is called once per frame
	void Update()
	{
		float curTime = animator.GetCurrentAnimatorStateInfo(0).normalizedTime;
		if (animator.GetCurrentAnimatorStateInfo(0).IsName("Lit"))
		{
			if (curTime >= 0.99f)
			{
				Debug.Log("over");
				Destroy(gameObject);
			}

			if (curTime >= 0.5f && lit == false)
			{
				lit = true;
				gameManager.SendMessage("GroupUp");
			}
		}
	}

	public void Lit()
	{
		animator.Play("Lit");
	}
}
