using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class CollisonDetection : MonoBehaviour
{
    public Transform ScalingTransform;
    private float ScalingX;
    private float ScalingY;
    private float ScalingZ;

    void Start()
    {
        var temp = GameObject.Find("Builduplocation");

        if (temp == null) return;

        ScalingTransform = temp.transform;
        ScalingX = 0.015f;
        ScalingY = 0.015f;
        ScalingZ = 0.015f;
    }

    void Update()
    {
        if (GameManager.Instance.IncreasedDifficulty == true && ScalingTransform != null) 
        {
            ScalingX = 0.006f;
            ScalingY = 0.006f;
            ScalingZ = 0.006f;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<Ring>()==true)
        {
            GameManager.Instance.Ringcombo();
            if (GameManager.Instance.RingWasHit != null)
            {
                GameManager.Instance.RingWasHit.Invoke();
            }
        }
        else
        {
            GameManager.Instance.RingCombo = 0;
            var newScale = ScalingTransform.localScale - new Vector3(ScalingX, ScalingY, ScalingZ);
            newScale.x = Mathf.Clamp(newScale.x, 0, 3.5f);
            newScale.y = newScale.x;
            newScale.z = newScale.x;

            ScalingTransform.localScale = newScale;
            ScalingTransform.gameObject.GetComponent<LocationScaling>().OldRingCount = GameManager.Instance.RingCount;

        }    
    }
}
