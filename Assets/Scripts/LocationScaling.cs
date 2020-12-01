using System.Collections;
using UnityEngine;

public class LocationScaling : MonoBehaviour
{
    public float OldRingCount;
    public GameObject Explode;
    public GameObject OverheadCloser;
    private float ScalingX;
    private float ScalingY;
    private float ScalingZ;

    void Start()
    {
        OldRingCount = GameManager.Instance.RingCount;
        GameManager.Instance.RingWasHit += IncreaseSize;
        ScalingX = 0.03f;
        ScalingY = 0.03f;
        ScalingZ = 0.03f;
    }

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
            //GameManager.Instance.GlobaleSpawners.SetActive(false);
            //EndGame();ay
            OverheadCloser.SetActive(true);
        }
    }

    void EndGame()
    {
        var AllRings = FindObjectsOfType<Ring>();

        foreach (var item in AllRings)
        {
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
        yield break;
    }
}
