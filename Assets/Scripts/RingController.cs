using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingController : MonoBehaviour
{
    public float Lifespan;
    public float ActivationDelay;
    public ParticleSystem RingParticles;

    void Start()
    {
        Invoke(nameof(Init), ActivationDelay);
    }

    private void Init()
    {
        var main = RingParticles.main;
        main.startLifetime = Lifespan;
        main.duration = Lifespan;

        RingParticles.Play();

        Destroy(gameObject, Lifespan + 0.1f);
    }

    private void OnDestroy()
    {
        RingManager.Instance.RingList.Remove(this);
    }
}
