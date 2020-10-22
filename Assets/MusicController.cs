using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    public AudioSource AudioSource;

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
