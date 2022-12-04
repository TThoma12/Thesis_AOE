using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMovement : MonoBehaviour
{
    public float moveSpeed;
    private Vector2 minWalkPoint;
    private Vector2 maxWalkPoint;
    private Rigidbody2D rb2d;
    public bool isWalking;

    public float walkTime;
    private float walkCounter;
    public float waitTime;
    private float waitCounter;

    private int WalkDirection;

    public Collider2D walkZone;
    private bool hasWalkZone;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        
        waitCounter = waitTime;
        walkCounter = walkTime;
        
        ChooseDirection();

        // This code will control whether the NPC can freely move around or not
        if (walkZone != null)
        {
            minWalkPoint = walkZone.bounds.min;
            maxWalkPoint = walkZone.bounds.max;
            hasWalkZone = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isWalking)
        {
            walkCounter -= Time.deltaTime;

            switch (WalkDirection)
            {
                case 0:
                    rb2d.velocity = new Vector2(0, moveSpeed);
                    
                    if (hasWalkZone && transform.position.y > maxWalkPoint.y)
                    {
                        isWalking = false;
                        waitCounter = waitTime;
                    }
                    
                    break;

                case 1:
                    rb2d.velocity = new Vector2(moveSpeed, 0);

                    if (hasWalkZone && transform.position.x > maxWalkPoint.x)
                    {
                        isWalking = false;
                        waitCounter = waitTime;
                    }
                    
                    break;

                case 2:
                    rb2d.velocity = new Vector2(0, -moveSpeed);

                    if (hasWalkZone && transform.position.y < minWalkPoint.y)
                    {
                        isWalking = false;
                        waitCounter = waitTime;
                    }
                    
                    break;

                case 3:
                    rb2d.velocity = new Vector2(-moveSpeed, 0);

                    if (hasWalkZone && transform.position.x > minWalkPoint.x)
                    {
                        isWalking = false;
                        waitCounter = waitTime;
                    }
                    
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

            rb2d.velocity = Vector2.zero;
            
            if (waitCounter < 0)
            {
                ChooseDirection();
            }
        }
    }

    // This code will control which direction the NPC will move in
    public void ChooseDirection()
    {
        WalkDirection = Random.Range(0, 4);
        isWalking = true;
        walkCounter = walkTime;
    }
}