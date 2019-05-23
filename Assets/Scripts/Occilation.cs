using System.Collections;
using UnityEngine;

public class Occilation : MonoBehaviour
{
    public enum OccilationFuntion { Sine, Cosine }
    public void Start()
    {
        StartCoroutine(Oscillate(OccilationFuntion.Sine, 1.5f));
        
    }

    private IEnumerator Oscillate(OccilationFuntion method, float scalar)
    {
        while (true)
        {
            if (method == OccilationFuntion.Sine)
            {
                transform.localPosition = new Vector3(Mathf.Sin(Time.time) * scalar, 0, 0);
            }
            else if (method == OccilationFuntion.Cosine)
            {
                transform.localPosition = new Vector3(Mathf.Cos(Time.time) * scalar, 0, 0);
            }
            yield return new WaitForEndOfFrame();
        }
    }







}
