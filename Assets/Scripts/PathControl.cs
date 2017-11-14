using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathControl : iTweenEvent
{
	float endTime;
	float startTime;
	GameObject manager;

	// Use this for initialization
	void Start()
	{
		endTime = -1;
		startTime = 0;
		manager = GameObject.Find("GameManager");
	}
	
	// Update is called once per frame
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.W))
		{
			iTween.Resume(gameObject);
		}
			
		if (Input.GetKeyUp(KeyCode.W))
		{
			iTween.Pause(gameObject);
		}

		if (startTime < endTime)
		{
			startTime += Time.deltaTime;
			if (startTime >= endTime)
			{
				Debug.Log("ohoh");
				manager.SendMessage("Over");
			}
		}
	}

	void Over()
	{
		Debug.Log("oh");
		startTime = Time.time;
		endTime = startTime + 3.0f;
	}
}
