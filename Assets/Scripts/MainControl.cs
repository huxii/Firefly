using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainControl : MonoBehaviour
{
	public GameObject player;
	public ParticleSystem fireflies;
	public GameObject unlitPrefab;
	public GameObject litPrefab;
	public GameObject rainPrefab;
	public GameObject loadingBgPrefab;
	public GameObject cloudPrefab;
	public AudioSource bgm;
	public AudioSource litSound;

	bool sea;

	// Use this for initialization
	void Start()
	{
		bgm.Play();
		sea = false;
	}

	// Update is called once per frame
	void Update()
	{
		if (sea)
		{
			Apart();
		}
	}

	public void WakeFirefly(GameObject target)
	{
		target.GetComponent<FireflyControl>().Lit();
		litSound.Play();
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

	public void StartRaining()
	{
		sea = true;
		rainPrefab.SetActive(true);
		cloudPrefab.SetActive(true);
	}

	public void StopRaining()
	{
		sea = false;
		rainPrefab.SetActive(false);
	}

	public void GroupUp()
	{
		var emission = fireflies.emission;
		float rate = emission.rateOverTime.constant + 3.0f;
		if (rate <= 200.0f)
		{
			emission.rateOverTime = rate;
		}
	}

	public void Apart()
	{
		var emission = fireflies.emission;
		float rate = emission.rateOverTime.constant - 1.0f;
		if (rate >= 0.0f)
		{
			emission.rateOverTime = rate;
		}
	}

	public void Over()
	{
		FadeOut();
		SceneManager.LoadScene("EndScene");
	}

	void FadeIn()
	{
		GameObject bg = Instantiate(loadingBgPrefab, new Vector3(0.0f, 0.0f, 0.0f), Quaternion.identity) as GameObject;
		bg.GetComponent<FadingControl>().fadingDir = -1;		
	}

	void FadeOut()
	{
		GameObject bg = Instantiate(loadingBgPrefab, new Vector3(0.0f, 0.0f, 0.0f), Quaternion.identity) as GameObject;
		bg.GetComponent<FadingControl>().fadingDir = 1;		
	}
}
