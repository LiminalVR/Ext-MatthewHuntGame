﻿using System.Collections;
using UnityEngine;

public class LocationScaling : MonoBehaviour
{
    public float OldRingCount;
    public GameObject Explode;
    public GameObject OverheadCloser;
    private float ScalingX;
    private float ScalingY;
    private float ScalingZ;

    // Use this for initialization
    void Start()
    {
        OldRingCount = GameManager.Instance.RingCount;
        GameManager.Instance.RingWasHit += IncreaseSize;
        ScalingX = 0.03f;
        ScalingY = 0.03f;
        ScalingZ = 0.03f;
    }

    // Update is called once per frame
    void IncreaseSize()
    {
        var newScale = transform.localScale + new Vector3(ScalingX, ScalingY, ScalingZ);
        newScale.x = Mathf.Clamp(newScale.x, 0, 3.5f);
        newScale.y = newScale.x;
        newScale.z = newScale.x;
        transform.localScale = newScale;



        if (transform.localScale.x >= 3.5 && transform.localScale.y >= 3.5f && transform.localScale.z >= 3.5f)
        {

            StartCoroutine("MoveLocation");
            GameManager.Instance.GlobaleSpawners.SetActive(false);
            EndGame();
            OverheadCloser.SetActive(true);

        }
    }
    void EndGame()
    {
        var AllRings = FindObjectsOfType<Ring>();

        foreach (var item in AllRings)
        {

            //destry here. yayayay
            Destroy(item.gameObject);

        }
    }

    void Update()
    {

        if (GameManager.Instance.IncreasedDifficulty == true)
        {
            ScalingX = 0.018f;
            ScalingY = 0.018f;
            ScalingZ = 0.018f;
        }

    }
    IEnumerator MoveLocation()
    {
        while (true)
        {
            if (transform.localPosition.y <= -11)
            {
                this.GetComponent<AudioSource>().Play();
                yield return null;
            }

            if (transform.localPosition.y <= -10)
            {
                transform.Translate(Vector3.up * Time.deltaTime, Space.World);
                Explode.transform.Translate(Vector3.up * Time.deltaTime, Space.World);
                yield return new WaitForEndOfFrame();
            }
            else
            {
                Explode.SetActive(true);
                GameManager.Instance.EndExperience();
                Destroy(gameObject);
                Destroy(Explode, 3);
                yield return null;
            }

        }
    }
}
