using UnityEngine;

public class Particle : MonoBehaviour
{

    public GameObject obj2;
    public float Speed;
    // Use this for initialization
    void Start()
    {
        obj2 = GameObject.Find("Builduplocation");
    }

    // Update is called once per frame
    void Update()
    {

    }
    void FixedUpdate()
    {
        if (obj2 == null)
        {
            Destroy(gameObject); 
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, obj2.transform.position, Speed * Time.deltaTime);
        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
}
