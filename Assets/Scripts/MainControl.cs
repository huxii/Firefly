using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainControl : MonoBehaviour
{
	public GameObject player;
	public ParticleSystem fireflies;
	public GameObject unlitPrefab;
	public GameObject litPrefab;

	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{

	}

	public void WakeFirefly(GameObject target)
	{
		target.GetComponent<FireflyControl>().Lit();
		//target.GetComponent<Animator>().Play("Lit");
		/*
		ParticleSystem ps = target.GetComponent<ParticleSystem>();
		ParticleSystem.Particle[] newP = new ParticleSystem.Particle[ps.particleCount];
		ps.GetParticles(newP);
		for (int i = 0; i < newP.Length; ++i)
		{
			ps.main.
		}

		ps.SetParticles(newP, newP.Length);
		*/

		/*
		Destroy(target);

		GameObject lit = Instantiate(litPrefab, target.transform.position, Quaternion.identity) as GameObject;
		*/
	}

	public void GroupUp()
	{
		var emission = fireflies.emission;
		float rate = emission.rateOverTime.constant + 3.0f;
		emission.rateOverTime = rate;
	}
}
