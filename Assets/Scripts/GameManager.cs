using System.Collections;
using System.Collections.Generic;
using Liminal.Core.Fader;
using Liminal.SDK.Core;
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
    public float RingRadious;
    public Vector3 Size;
    public Vector3 Center;
    public Vector3 Size2;
    public Vector3 Center2;
    public Vector3 Size3;
    public Vector3 Center3;
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
    [Space]
    public float MaxGameTime;
    public AudioSource AudioSource;
    public AudioClip EndClip;
    
    private Coroutine GameTimeRoutine;

    void Start()
    {
        Instance = this;
        Time.timeScale = 0f;
        QuitTime = 11f;
    }

    private IEnumerator GameTimer()
    {
        while (GlobalTimer < MaxGameTime)
        {
            GlobalTimer += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }

        QuitGame();
    }

    public void RingCountUP()
    {
        RingCount++;

        switch (RingCount)
        {
            case 30:
                FireBurst1.SetActive(true);
                return;
            case 60:
                FireBurst2.SetActive(true);
                return;
            case 90:
                FireBurst3.SetActive(true);
                return;
            case 100:
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
            GameTimeRoutine = StartCoroutine(GameTimer());
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
        if (GameTimeRoutine != null)
        {
            StopCoroutine(GameTimeRoutine);
        }

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

    public void QuitGame()
    {
        if (GameTimeRoutine != null)
        {
            StopCoroutine(GameTimeRoutine);
        }

        StartCoroutine(routine(2f));

        IEnumerator routine(float fadeOutTime)
        {
            RingManager.Instance.CanSpawn = false;
            Time.timeScale = 1f;
            //do simulation over effects.
            AudioSource.clip = EndClip;
            AudioSource.Play();

            yield return new WaitForEndOfFrame();

            while (AudioSource.isPlaying)
                yield return new WaitForEndOfFrame();

            var elapsedTime = 0f;
            var startingVolume = AudioListener.volume;

            ScreenFader.Instance.FadeToBlack(fadeOutTime);

            while (elapsedTime < fadeOutTime)
            {
                elapsedTime += Time.deltaTime;
                AudioListener.volume = Mathf.Lerp(startingVolume, 0f, elapsedTime / fadeOutTime);
                yield return new WaitForEndOfFrame();
            }

            ExperienceApp.End();
        }
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
