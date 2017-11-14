using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
	public Transform fireflyRef;
	public Transform fireflyTrans;
	public float fireflyRadius = 3.0f;
	public Vector2 fireflyOffset;
	public float speed = 3.0f;

	GameObject gameManager;
	Rigidbody rb;
	float posRandom;

	// Use this for initialization
	void Start()
	{
		rb = GetComponent<Rigidbody>();
		posRandom = Random.Range(0, 30);
		gameManager = GameObject.Find("GameManager");
	}

	void Update()
	{
		float x = fireflyRadius * Mathf.Cos(Time.time + posRandom) + fireflyOffset.x;
		float y = fireflyRadius * Mathf.Sin(Time.time + posRandom) + fireflyOffset.y;
		fireflyTrans.localPosition = new Vector3(x, y, fireflyTrans.localPosition.z);
	}

	// Update is called once per frame
	void FixedUpdate()
	{
		/*
		if (Input.GetKey(KeyCode.W))
		{
			if (path.Count > 0)
			{
				transform.position = Vector3.MoveTowards(transform.position, path[0], Time.deltaTime * 3F);
				if (Mathf.Abs(transform.position.z - path[0].z) < 0.4F)
				{
					path.RemoveAt(0);
				}
				//gameObject.GetComponent<Pathfinding>().FindPath(endTrans.position, startTrans.position);
				//Debug.Log(gameObject.GetComponent<Pathfinding>().Path.Count);
				//gameObject.GetComponent<Pathfinding>().Move();
			}
		}
		*/
	
		Vector3 v = rb.velocity;

		if (Input.GetKeyUp(KeyCode.D))
		{
			v.x = 0;
		}
		else
		if (Input.GetKeyUp(KeyCode.A))
		{
			v.x = 0;
		}
		else
		if (Input.GetKeyUp(KeyCode.W))
		{
			//v.z = 0;
		}
		else
		if (Input.GetKeyUp(KeyCode.S))
		{
			//v.z = 0;
		}
		else
		{
			//rb.velocity = new Vector3(0, 0, 0);
		}

		if (Input.GetKeyDown(KeyCode.D))
		{
			v.x = speed * 0.4f;
		}
		else
		if (Input.GetKeyDown(KeyCode.A))
		{
			v.x = -speed * 0.4f;
		}
		else
		if (Input.GetKeyDown(KeyCode.W))
		{
			//v.z = speed;
		}
		else
		if (Input.GetKeyDown(KeyCode.S))
		{
			//v.z = -speed;
		}
		else
		{
			//rb.velocity = new Vector3(0, 0, 0);
		}
		
		rb.velocity = v;

		Vector3 desiredPos = new Vector3(transform.position.x, fireflyRef.position.y, fireflyRef.position.z);
		transform.position = Vector3.Slerp(transform.position, desiredPos, Time.deltaTime * 3f);
	}

	void OnTriggerEnter(Collider target)
	{
		if (target.gameObject.tag == "Unlit")
		{
			gameManager.SendMessage("WakeFirefly", target.gameObject);

			//Vector3 pos = target.gameObject.transform.position;

			/*
			ParticleSystem ps = target.gameObject.GetComponent<ParticleSystem>();


			ParticleSystem nps = new ParticleSystem();
			ParticleSystem.Particle[] np;
			nps.GetParticles(np);
			for (int i = 0; i < np.Length; ++i)
			{
				np[i].startSize = 30;
			}

			nps.SetParticles(np, np.Length);
			target.gameObject.GetComponent<ParticleSystem>() = nps;
			*/

		}
		else
		if (target.gameObject.tag == "Sea")
		{
			gameManager.SendMessage("StartRaining", target.gameObject);
		}
		else
		if (target.gameObject.tag == "Moon")
		{
			gameManager.SendMessage("StopRaining", target.gameObject);
		}
	}
}
