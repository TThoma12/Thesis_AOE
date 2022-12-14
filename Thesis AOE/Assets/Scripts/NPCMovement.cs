using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMovement : MonoBehaviour
{

    public float moveSpeed;
    private Vector2 minWalkPoint;
    private Vector2 maxWalkPoint;

    private Rigidbody2D rb;
    public bool isWalking;

    public Vector2 facing;

    public float walkTime;
    private float walkCounter;
    public float waitTime;
    private float waitCounter;

    private Vector2 startPosition;
    private int walkDirection;

    public Collider2D walkZone;
    private bool hasWalkZone;

    //public Animator anim;

    void Start()
    {
        startPosition = transform.position;
        rb = GetComponent<Rigidbody2D>();
        //anim = GetComponent<Animator>();
        waitCounter = waitTime;
        walkCounter = walkTime;

        ChooseDirection();

        if (walkZone != null)
        {
            minWalkPoint = walkZone.bounds.min;
            maxWalkPoint = walkZone.bounds.max;
            hasWalkZone = true;
        }
    }


    void Update()
    {
        if (isWalking == false)
        {
            facing.x = 0;
            facing.y = 0;
        }

        if (transform.position.y > maxWalkPoint.y)
        {
            transform.position = startPosition;
        }

        if (isWalking == true)
        {
            walkCounter -= Time.deltaTime;


            switch (walkDirection)
            {


                case 0:
                    if (hasWalkZone && transform.position.y > maxWalkPoint.y)
                    {
                        rb.velocity = new Vector2(0, -moveSpeed);
                    }
                    else
                    {
                        rb.velocity = new Vector2(0, moveSpeed);
                    }
                    if (hasWalkZone && transform.position.y > maxWalkPoint.y)
                    {
                        isWalking = false;
                        waitCounter = waitTime;
                    }
                    facing.y = 1;
                    facing.x = 0;
                    break;

                case 1:
                    rb.velocity = new Vector2(moveSpeed, 0);
                    if (hasWalkZone && transform.position.x > maxWalkPoint.x)
                    {
                        isWalking = false;
                        waitCounter = waitTime;
                    }
                    facing.x = 1;
                    facing.y = 0;
                    //transform.localScale = new Vector3(6f, 6f, 1f);
                    break;

                case 2:
                    rb.velocity = new Vector2(0, -moveSpeed);
                    if (hasWalkZone && transform.position.y > minWalkPoint.y)
                    {
                        isWalking = false;
                        waitCounter = waitTime;
                    }
                    facing.y = -1;
                    facing.x = 0;
                    break;

                case 3:
                    rb.velocity = new Vector2(-moveSpeed, 0);
                    if (hasWalkZone && transform.position.x > minWalkPoint.x)
                    {
                        isWalking = false;
                        waitCounter = waitTime;
                    }
                    facing.y = 0;
                    facing.x = -1;
                    //transform.localScale = new Vector3(-6f, 6f, 1f);

                    break;





            }

            if (walkCounter < 0)
            {
                isWalking = false;
                waitCounter = waitTime;
            }
        }
        else
        {
            rb.velocity = Vector2.zero;

            waitCounter -= Time.deltaTime;

            if (waitCounter < 0)
            {
                ChooseDirection();
            }
        }

        //anim.SetFloat("YourFloat", facing.x);
        //anim.SetFloat("YourFloat", facing.y);
        //anim.SetBool("YourBool", isWalking);
    }

    public void ChooseDirection()
    {
        walkDirection = Random.Range(0, 4);
        isWalking = true;
        walkCounter = walkTime;
    }
}
