using System.Collections;
using UnityEngine;

public class QuitUIFade : MonoBehaviour
{
    public CanvasGroup UIelements;

    void Start()
    {

    }
    public void FadeIn()
    {
        StartCoroutine(FadeCanvasGroup(UIelements, UIelements.alpha, 1));
    }
    public void FadeOut()
    {
        StartCoroutine(FadeCanvasGroup(UIelements, UIelements.alpha, 0));
    }
    public IEnumerator FadeCanvasGroup(CanvasGroup CG, float Start, float End, float LerpTime = 0.5f)
    {
        float TimeStartLerp = Time.time;
        float timesincestarted = Time.time - TimeStartLerp;
        float percentageComplete = timesincestarted / LerpTime;

        while (true)
        {
            timesincestarted = Time.time - TimeStartLerp;
            percentageComplete = timesincestarted / LerpTime;

            float currentvalue = Mathf.Lerp(Start, End, percentageComplete);

            CG.alpha = currentvalue;

            if (percentageComplete >= 1) break; 
            

            yield return new WaitForEndOfFrame();

        }
    }
}
