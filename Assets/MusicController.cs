using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    public AudioSource AudioSource;
    public float StartFadeInTime;
    public float FadeInLength;

    private IEnumerator Start()
    {
        yield return new WaitForSeconds(StartFadeInTime);

        var elapsedTime = 0f;
        var startingVolume = AudioSource.volume;

        while (elapsedTime < FadeInLength)
        {
            elapsedTime += Time.deltaTime;
            AudioSource.volume = Mathf.Lerp(startingVolume, 1f, elapsedTime / FadeInLength);

            yield return new WaitForEndOfFrame();

        }

    }

    public void KillMusic(float targetVolume, float fadeTime)
    {
        StartCoroutine(routine());
        IEnumerator routine()
        {
            var elapsedTime = 0f;
            var startingVolume = AudioSource.volume;

            while (elapsedTime < fadeTime)
            {
                elapsedTime += Time.deltaTime;
                AudioSource.volume = Mathf.Lerp(startingVolume, targetVolume, elapsedTime / fadeTime);

                yield return new WaitForEndOfFrame();

            }

            AudioSource.volume = 0f;
        }
    }

}
