using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class RingCount : MonoBehaviour {

    // Use this for initialization
    void Start () {
        this.GetComponent<Text>().text = ("" + GameManager.Instance.RingCount.ToString());
    }
    
    // Update is called once per frame
    void Update () {
        this.GetComponent<Text>().CrossFadeAlpha(0, 1, true);
    }
}
