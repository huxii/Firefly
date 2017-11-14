using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingControl : MonoBehaviour
{
	//public Slider loadingBar;
	public Text loadingText;
	public GameObject loadingBgPrefab;
	public Canvas title;
	public GameObject grass;
	public GameObject rotten;
	public bool grow;

	Animator grassAnim;
	Animator rottenAnim;
	bool ready;

	AsyncOperation ao;

	// Use this for initialization
	void Start()
	{
		FadeIn();

		grassAnim = grass.GetComponent<Animator>();
		rottenAnim = rotten.GetComponent<Animator>();

		ready = false;

		if (grow)
		{
			Grow();
		}
		else
		{
			Rotten();
		}
	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetKeyUp(KeyCode.Space))
		{
			FadeOut();
			SceneManager.LoadScene("GameScene");
			Loading();
		}

		if (!ready)
		{
			if (grow)
			{
				if (rottenAnim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.99f)
				{
					grassAnim.speed = 0.3f;
				}
			}
			else
			{
				if (grassAnim.GetCurrentAnimatorStateInfo(0).normalizedTime <= 0.2f)
				{
					rottenAnim.Play("Rotten", 0, 1.0f);
				}			
			}

			ready = true;
		}
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

	public void Grow()
	{
		ready = false;
		grassAnim.SetFloat("Direction", 1.0f);
		rottenAnim.SetFloat("Direction", 1.0f);
		rottenAnim.Play("Rotten", 0, 0.0f);
		grassAnim.Play("Grow", 0, 0.0f);
		//grassAnim.speed = 0.0f;
	}

	public void Rotten()
	{
		ready = false;
		grassAnim.SetFloat("Direction", -1.0f);
		rottenAnim.SetFloat("Direction", -1.0f);
		grassAnim.Play("Grow", 0, 1.0f);
		//rottenAnim.Play("Rotten", 0, 1.0f);
	}

	public void Loading()
	{
		FadeIn();

		//loadingBar.gameObject.SetActive(true);
		//loadingText.gameObject.SetActive(true);
		loadingText.text = "Loading...";
		title.gameObject.SetActive(false);

		StartCoroutine(LoadLevelWithRealProgress());
	}

	IEnumerator LoadLevelWithRealProgress()
	{
		yield return new WaitForSeconds(1);

		ao = SceneManager.LoadSceneAsync(1);
		ao.allowSceneActivation = false;

		while (!ao.isDone)
		{
			//loadingBar.value = ao.progress;

			if (ao.progress == 0.9f)
			{
				//loadingBar.value = 1.0f;
				loadingText.text = "Press 'SPACE' to continue";
				if (Input.GetKeyDown(KeyCode.Space))
				{
					//print(",,,,,,,,,,");
					FadeIn();
					ao.allowSceneActivation = true;
				}
			}

			//Debug.Log(ao.progress);
			yield return null;
		}
	}
}
