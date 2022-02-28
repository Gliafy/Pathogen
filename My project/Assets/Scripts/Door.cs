using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{

    private Animator animator;


    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void OpenDoor()
    {
        animator.SetBool("Open", true);
    }

    public void CloseDoor()
    {
        animator.SetBool("Open", false);
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        OpenDoor();
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        CloseDoor();
    }
}
