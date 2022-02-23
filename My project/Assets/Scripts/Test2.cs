using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<PlayerMovement>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            this.GetComponent<PlayerMovement>().enabled = true;
            Destroy(transform.GetChild(0).gameObject);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            this.GetComponent<PlayerMovement>().enabled = false;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("test");
            this.GetComponent<SpriteRenderer>().enabled = false;
        }



    }
}
