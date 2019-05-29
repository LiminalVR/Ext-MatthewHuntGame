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
