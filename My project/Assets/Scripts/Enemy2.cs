using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : MonoBehaviour
{



    [SerializeField]
    Transform castPoint;

    [SerializeField]
    Transform player;

    [SerializeField]
    float agroRange;

    [SerializeField]
    float moveSpeed;

    Rigidbody2D rb2d;

    bool isFacingLeft;

    private bool isAgro = false;
    private bool isSearching;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();


    }

    // Update is called once per frame
    void Update()
    {
        if (CanSeePlayer(agroRange))

        {

            //agro enemy
            isAgro = true;


        }
        else
        {
            if (isAgro)
            {
                if (!isSearching)
                {

                    isSearching = true;


                    Invoke("StopChasingPlayer", 5);

                }


            }




        }
        if (isAgro)
        {
            ChasePlayer();
        }
        bool CanSeePlayer(float distance)
        {

            bool val = false;
            float castDist = distance;

            if (isFacingLeft)
            {
                castDist = -distance;


            }


            Vector2 endPos = castPoint.position + Vector3.right * castDist;
            RaycastHit2D hit = Physics2D.Linecast(castPoint.position, endPos, 1 << LayerMask.NameToLayer("Action"));

            if (hit.collider != null)
            {
                if (hit.collider.gameObject.CompareTag("layer"))
                {
                    //Lets Agro The enemy
                    val = true;

                }
                else
                {
                    val = false;

                }
                Debug.DrawLine(castPoint.position, hit.point, Color.yellow);
            }
            else
            {
                Debug.DrawLine(castPoint.position, endPos, Color.blue);



            }
            return val;


        }


        void ChasePlayer()
        {
            if (transform.position.x < player.position.x)
            {
                //enemy is to the left side of the player, so move right
                rb2d.velocity = new Vector2(moveSpeed, 0);
                transform.localScale = new Vector2(-1, 1);
                isFacingLeft = false;

            }


            else
            {
                //enemy is to the right side of the player, so move left
                rb2d.velocity = new Vector2(-moveSpeed, 0);
                transform.localScale = new Vector2(1, 1);
                isFacingLeft = true;
            }


        }


        {
            isAgro = false;
            isSearching = false;
            rb2d.velocity = new Vector2(0, 0);



        }






    }

}
