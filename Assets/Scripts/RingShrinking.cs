using System.Collections;
using UnityEngine;

public class RingShrinking : MonoBehaviour
{
    public GameObject particleSystem;
    Vector3 MinScale;
    Vector3 maxscale;
    bool Reapeatable;
    public float speed = 2f;
    public float duration = 2f;
    public GameObject prefabeparent;
    public GameObject DyingPrefab;
    public Vector3 Pos;
    public bool HasBeenHit = false;
    public GameObject RingcountCanvas;

    IEnumerator scale()
    {
        MinScale = transform.localScale;
        while (Reapeatable)
        {
            yield return Repeatlerp(MinScale, maxscale, duration);
            yield return Repeatlerp(maxscale, MinScale, duration);
        }
    }

    public IEnumerator Repeatlerp(Vector3 a, Vector3 b, float time)
    {
        float i = 0.0f;
        float rate = (1.0f / time) * speed;
        while (i < 1.0f)
        {
            i += Time.deltaTime * rate;

            transform.localScale = Vector3.Lerp(a, b, i);
            yield return null;
        }
    }
    
    void Update()
    {
        Pos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
    }
    
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Projectile>() == true)
        {
            this.GetComponent<SphereCollider>().enabled = false;
            Instantiate(DyingPrefab, Pos, Quaternion.identity);
            Reapeatable = true;

            StartCoroutine("scale");

            particleSystem.GetComponent<ParticleSystem>().Play();
            GameManager.Instance.RingCountUP();

            Destroy(other.gameObject);

            gameObject.GetComponent<AudioSource>().Play();
            RingcountCanvas.SetActive(true);

            Destroy(prefabeparent, 2);

            GameManager.Instance.RingsAlive--;
            RingManager.Instance.RingList.RemoveAt(0); 
        }
    }
}
