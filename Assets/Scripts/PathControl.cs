using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathControl : iTweenEvent
{

	// Use this for initialization
	void Start()
	{
		//iTween.Pause();
	}
	
	// Update is called once per frame
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.W))
		{
			iTween.Resume();
		}
			
		if (Input.GetKeyUp(KeyCode.W))
		{
			iTween.Pause();
		}
	}
}
