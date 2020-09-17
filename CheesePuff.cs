using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheesePuff : MonoBehaviour
{
    RingSpawner ringSpawner;

    // Start is called before the first frame update
    void Awake()
    {
        ringSpawner = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<RingSpawner>();
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "ring")
        {
            Destroy(collider.gameObject);
            ringSpawner.SpawnRing();

            Destroy(this.gameObject);
        }
    }

    void OnCollisionEnter(Collider collider)
    {
        if (collider.tag == "walls")
        {
            Destroy(this.gameObject);
        }
    }
}
