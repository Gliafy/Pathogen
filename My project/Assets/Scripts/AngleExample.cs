using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AngleExample : MonoBehaviour
{
    public Transform target;

    // prints "close" if the z-axis of this transform looks
    // almost towards the target

    void Update()
    {
        Vector2 targetDir = target.position - transform.position;
        float angle = Vector2.Angle(targetDir, transform.forward);

        if (angle < 5.0f)
            print("close");
    }
}

