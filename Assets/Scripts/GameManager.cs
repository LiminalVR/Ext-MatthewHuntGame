using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
	public static GameManager Instance;
	public float GlobalTimer;
	public GameObject Player;
	public float RingCount;
	public float RingCombo;
	public int RingsAlive;
	public List<GameObject> _RingList = new List<GameObject>();
	public float RingRadious;
	public Vector3 Size;
	public Vector3 Center;
	public Vector3 Size2;
	public Vector3 Center2;
	public Vector3 Size3;
	public Vector3 Center3;
	public GameObject RingPrefab;
	public GameObject Spawner_active1;
	public GameObject Spawner_active2;
	public GameObject GameExperience;
	public GameObject GlobaleSpawners;
	public int TimesFired;
	public delegate void RingHit();
	public RingHit RingWasHit;
	public GameObject FireBurst1;
	public GameObject FireBurst2;
	public GameObject FireBurst3;
	public GameObject FireBurst4;
	public bool Timeon = true;
	public float QuitTime;
	public Vector3 RingPos1;
	public Vector3 RingPos2;
	public Vector3 RingPos3;
	public bool HasGameStarted = false;
	public float Accuracy;
	public float HighestCombo = 0;
	public Text AccuracyText;
	public Text HighestComboText;
	public Text GlobalTimerText2;
	public Text RingsHit;
	public Text ShotCount;
	public CanvasGroup PanelGroup2;
	public GameObject ArrowOne;
	public GameObject ArrowTwo;
	public bool IsGameOver;
	public bool IncreasedDifficulty;
	// Use this for initialization
	void Start()
	{
		Instance = this;
		Time.timeScale = 0f;
		QuitTime = 11f;
	}

	// Update is called once per frame
	void Update()
	{
		GlobalTimer += Time.deltaTime;

	}
	public void RingCountUP()
	{
		RingCount++;
		if (RingCount == 30)
		{
			FireBurst1.SetActive(true);
			return;
		}
		if (RingCount == 60)
		{
			FireBurst2.SetActive(true);
			return;
		}
		if (RingCount == 90)
		{
			FireBurst3.SetActive(true);
			return;
		}
		if (RingCount == 100)
		{
			FireBurst4.SetActive(true);
			return;
		}

	}
	public void Ringcombo()
	{
		RingCombo++;

		if (RingCombo >= HighestCombo)
		{
			HighestCombo = RingCombo;
		}
	}
	public void StartGame()
	{
		if (IsGameOver == false)
		{
			GameExperience.SetActive(true);
			Time.timeScale = 1f;
			HasGameStarted = true;
			PanelGroup2.GetComponent<QuitUIFade>().FadeOut();
		}


	}
	public void PauseGame()
	{
		if (IsGameOver == false)
		{
			Time.timeScale = 0f;
			GameExperience.SetActive(false);

		}


	}

	public void SpawnRings1()
	{


		RingPos1 = Center + new Vector3(UnityEngine.Random.Range(-Size.x / 2, Size.x / 2), UnityEngine.Random.Range(-Size.y / 2, Size.y / 2), UnityEngine.Random.Range(-Size.z / 2, Size.z / 2));

		GameObject NewRings = (GameObject)Instantiate(RingPrefab, RingPos1, Quaternion.identity);
		_RingList.Add(NewRings);
		RingsAlive++;
	}

	public void SpawnRings2()
	{

		RingPos2 = Center2 + new Vector3(UnityEngine.Random.Range(-Size2.x / 2, Size2.x / 2), UnityEngine.Random.Range(-Size2.y / 2, Size2.y / 2), UnityEngine.Random.Range(-Size2.z / 2, Size2.z / 2));
		GameObject NewRings = (GameObject)Instantiate(RingPrefab, RingPos2, Quaternion.identity);
		_RingList.Add(NewRings);
		RingsAlive++;
	}

	public void SpawnRings3()
	{

		RingPos3 = Center3 + new Vector3(UnityEngine.Random.Range(-Size3.x / 2, Size3.x / 2), UnityEngine.Random.Range(-Size3.y / 2, Size3.y / 2), UnityEngine.Random.Range(-Size3.z / 2, Size3.z / 2));
		GameObject NewRings = (GameObject)Instantiate(RingPrefab, RingPos3, Quaternion.identity);
		_RingList.Add(NewRings);
		RingsAlive++;
	}
	public void IncreaseDifficulty()
	{
		if (IsGameOver == false)
		{
			Spawner_active1.SetActive(true);
			Spawner_active2.SetActive(true);
			IncreasedDifficulty = true;
		}



	}


	public void EndExperience()
	{
		StartCoroutine(EndRoutine());
	}

	private IEnumerator EndRoutine()
	{
		yield return new WaitForSeconds(QuitTime);

		this.GetComponent<QuitUIFade>().FadeIn();

		yield return new WaitForSeconds(1);
		Time.timeScale = 0;
		GameObject AudioSource = GameObject.Find("Audio Source");
		AudioSource.GetComponent<AudioSource>().Pause();

		Accuracy = ((RingCount / TimesFired) * 100);
		AccuracyText.text = ("Accuracy: " + Accuracy.ToString("f2") + "%");
		GlobalTimerText2.text = ("Timer: " + GlobalTimer.ToString("F2"));
		HighestComboText.text = ("Highest Combo: " + HighestCombo.ToString());
		RingsHit.text = ("Rings Hit: " + RingCount.ToString());
		ShotCount.text = ("Times Fired: " + TimesFired.ToString());
		TurnoffOBJS();

		ArrowOne.SetActive(false);
		ArrowTwo.SetActive(false);
		IsGameOver = true;

	}

	public void QuiteGame()
	{
		Application.Quit();


	}
	public void TurnoffOBJS()
	{
		GameObject AllGameOBJ = GameObject.Find("GameObjects");
		if (AllGameOBJ != null)
		{
			AllGameOBJ.SetActive(false);
		}


	}


}
