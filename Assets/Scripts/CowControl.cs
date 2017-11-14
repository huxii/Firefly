﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CowControl : MonoBehaviour
{
	Animator animator;

	// Use this for initialization
	void Start()
	{
		animator = GetComponent<Animator>();
		animator.speed = 0;
	}
	
	// Update is called once per frame
	void Update()
	{
		
	}

	void OnTriggerEnter(Collider target)
	{
		if (target.gameObject.tag == "Player")
		{
			animator.speed = 1.0f;
			iTween.Resume(gameObject);
		}
	}
}
