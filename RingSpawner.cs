using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingSpawner : MonoBehaviour
{
    // Ring Prefab
    public GameObject ringPrefab;

    // Y and Z spawn boundaries (X is calculated later based off of Z)
    [Range(2, 6)]
    public float yMin = 4f;
    [Range(8, 12)]
    public float yMax = 10f;
    [Range(-2, 2)]
    public float zMin = 0f;
    [Range(12, 14)]
    public float zMax = 14f;

    // [Range(0.005f, 0.02f)]
    // public float scaleMin = 0.01f;
    // [Range(0.025f, 0.1f)]
    // public float scaleMax = 0.05f;

    void Start()
    {
        SpawnRing();
    }

    // Spawns a ring within the set boundaries
    public void SpawnRing()
    {
        float zPos = Random.Range(zMin, zMax);
        float xPos = Random.Range
        (
            (0.5f * zPos + 2f) * -1f, //xMin
            (0.5f * zPos + 2f) //xMax
        );
        float yPos = Random.Range(yMin, yMax);

        Vector3 ringPos = new Vector3(xPos, yPos, zPos);
        // float scale = Random.Range(scaleMin, scaleMax);

        Instantiate(ringPrefab, ringPos, Quaternion.identity);
    }
}
