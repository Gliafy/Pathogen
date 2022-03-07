using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class States : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        this.GetComponent<Follow>().enabled = true;
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        this.GetComponent<Follow>().enabled = false;
    }
}
