using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterControl : MonoBehaviour
{
	public Vector2 speed;

	MeshRenderer meshRender;
	Vector2 cur;

	// Use this for initialization
	void Start()
	{
		meshRender = GetComponent<MeshRenderer>();
		cur.x = meshRender.material.mainTextureOffset.x;
		cur.y = meshRender.material.mainTextureOffset.y;
	}
	
	// Update is called once per frame
	void Update()
	{
		cur.x += Time.deltaTime * speed.x;
		cur.y += Time.deltaTime * speed.y;

		meshRender.material.mainTextureOffset = cur;
	}
}
