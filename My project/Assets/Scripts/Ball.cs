using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

    private bool isPressed;
    private float releaseDelay;
    private Rigidbody2D rb;
    private SpringJoint2D sj;
    private float maxDragDistance = 2f;
    private Rigidbody2D slingRb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sj = GetComponent<SpringJoint2D>();
        slingRb = sj.connectedBody;
        releaseDelay = 1 / (sj.frequency * 4);

    }

    void Update()
    {
        if(isPressed)
        {
            DragBall();
        }
    }

    private void DragBall()
    {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float distance = Vector2.Distance(mousePosition, slingRb.position);


        if(distance > maxDragDistance)
        {
            Vector2 direction = (mousePosition - slingRb.position).normalized;
            rb.position = slingRb.position + direction * maxDragDistance;
        }
        else
        {
            rb.position = mousePosition;
        }

            
    }

    private void OnMouseDown()
    {
        isPressed = true;
        rb.isKinematic = true;
    }

    private void OnMouseUp()
    {
        isPressed = false;
        rb.isKinematic = false;
            StartCoroutine(Release());
    }

    private IEnumerator Release()
    {
        yield return new WaitForSeconds(releaseDelay);
        sj.enabled = false;
    }
}
