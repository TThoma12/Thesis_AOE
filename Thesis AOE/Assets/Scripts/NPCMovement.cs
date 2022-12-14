using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMovement : MonoBehaviour
{

    public float moveSpeed;
    private float storedMoveSpeed;
    private Vector2 minWalkPoint;
    private Vector2 maxWalkPoint;

    private Rigidbody2D rb;
    public bool isWalking;
    public Vector2 facing;
    public Vector2 movement;

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
        storedMoveSpeed = moveSpeed;
        moveSpeed = 0;
        startPosition = transform.position;
        rb = GetComponent<Rigidbody2D>();
        //anim = GetComponent<Animator>();
        waitCounter = waitTime;
        walkCounter = walkTime;

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
            movement.x = 0;
            movement.y = 0;
        }

        if (isWalking == true)
        {
            walkCounter -= Time.deltaTime;


            switch (walkDirection)
            {
                case 0:
                    if (hasWalkZone && transform.position.y < maxWalkPoint.y)
                    {
                        movement = new Vector2(0, 1);
                        moveSpeed = storedMoveSpeed;
                        rb.MovePosition(rb.position + movement * moveSpeed * Time.deltaTime);
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
                    if (hasWalkZone && transform.position.x < maxWalkPoint.x)
                    {
                        movement = new Vector2(1, 0);
                        moveSpeed = storedMoveSpeed;
                        rb.MovePosition(rb.position + movement * moveSpeed * Time.deltaTime);
                    }

                    if (hasWalkZone && transform.position.x > maxWalkPoint.x)
                    {
                        isWalking = false;
                        waitCounter = waitTime;
                    }
                    facing.x = 1;
                    facing.y = 0;
                    //transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
                    break;

                case 2:
                    if (hasWalkZone && transform.position.y > minWalkPoint.y)
                    {
                        movement = new Vector2(0, -1);
                        moveSpeed = -storedMoveSpeed;
                        rb.MovePosition(rb.position - movement * moveSpeed * Time.deltaTime);
                    }

                    if (hasWalkZone && transform.position.y < minWalkPoint.y)
                    {
                        isWalking = false;
                        waitCounter = waitTime;
                    }
                    facing.y = -1;
                    facing.x = 0;
                    break;

                case 3:
                    if (hasWalkZone && transform.position.x > minWalkPoint.x)
                    {
                        movement = new Vector2(-1, 0);
                        moveSpeed = -storedMoveSpeed;
                        rb.MovePosition(rb.position - movement * moveSpeed * Time.deltaTime);
                    }

                    if (hasWalkZone && transform.position.x < minWalkPoint.x)
                    {
                        isWalking = false;
                        waitCounter = waitTime;
                    }
                    facing.y = 0;
                    facing.x = -1;
                    //transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);

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
