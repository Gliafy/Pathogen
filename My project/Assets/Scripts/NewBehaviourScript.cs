using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class NewBehaviourScript : MonoBehaviour
{
    public GameObject z;
    private void OnTriggerStay2D(Collider2D collision)
    {

        if (collision.CompareTag("Player"))
        {

             
                SceneManager.LoadScene(2);
            

        }

    }       
}
