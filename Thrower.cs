using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thrower : MonoBehaviour
{
    // Cheese Puff Prefab
    public GameObject cheesePuffPrefab;
    // Position of the touch/swipe in screenspace
    Vector2 touchStart, touchDelta;
    // Time touch/swipe was held for
    float touchTimeStart, touchTimeDelta;

    // Tuning variables
    [Range(0, 2)]
    public float hor_Sensitivity = 1f;
    [Range(0, 2)]
    public float ver_Sensitivity = 1f; 
    [Range(0, 1000)]

    public float throwPower = 500f;
    [Range(500, 1000)]
    public float maxVertPower = 600f;
    [Range(0, 1)]
    public float maxSwipeDuration = 0.5f;


    void Start()
    {
        Time.timeScale = 1.5f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            // Store touch in var
            Touch touch = Input.GetTouch(0);

            // First frame of touch
            if (touch.phase == TouchPhase.Began)
            {
                touchTimeStart = Time.unscaledTime;
                touchStart = touch.position; // returns position in screenspace    
            }


            // Last frame of touch
            if (touch.phase == TouchPhase.Ended)
            {
                touchTimeDelta = Time.unscaledTime - touchTimeStart;
                touchDelta = touch.position - touchStart;

                StartCoroutine(ThrowCheesePuff(touchStart, touchDelta, touchTimeDelta));
            }
        }
    }

    // Instantiate Cheese Puff and Apply Force
    IEnumerator ThrowCheesePuff(Vector2 startingPoint, Vector2 touchDelta, float touchDuration)
    {
        Vector3 spawnPosition = Camera.main.ScreenToWorldPoint(new Vector3 (startingPoint.x, startingPoint.y - 2f, 1f));
        Quaternion spawnRotation = this.transform.rotation;

        float throwPower = Mathf.Max(((maxSwipeDuration - touchDuration) * 2f), 0f);
        Vector3 throwForce = new Vector3
        (
            touchDelta.x * hor_Sensitivity, //x
            Mathf.Min(touchDelta.y * ver_Sensitivity, maxVertPower) * throwPower, //y
            throwPower * 500f //z
        );

        GameObject cheesePuff = Instantiate(cheesePuffPrefab, spawnPosition, spawnRotation);

        cheesePuff.GetComponent<Rigidbody>().AddForce(throwForce);

        yield return new WaitForSeconds(5);
        Destroy(cheesePuff);
    }
}
