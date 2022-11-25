using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundBehavior : MonoBehaviour
{
    private Vector3 directionVector;
    private Transform myTransform;
    public float moveSpeed;
    private Rigidbody2D rb2d;
    private Animator animator;
    public Collider2D bounds;
    public bool playerInRange;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        myTransform = GetComponent<Transform>();
        rb2d = GetComponent<Rigidbody2D>();
        ChangeDirection();
    }

    // Update is called once per frame
    void Update()
    {
        // This code will prevent the NPC from moving if the player is within a certain range

        if (!playerInRange)
        {
            Move();
        }
    }

    private void Move()
    {
        // This code will keep the NPC within the boundaries
        Vector3 temp = myTransform.position + directionVector * moveSpeed * Time.deltaTime;

        if (bounds.bounds.Contains(temp))
        {
            rb2d.MovePosition(temp);
        }

        else
        {
            ChangeDirection();
        }
    }

    void ChangeDirection()
    {
        int direction = Random.Range(0, 4);

        // This code will control which direction the NPC moves in
        switch (direction)
        {
            case 0:
                // Walking right
                directionVector = Vector3.right;
                break;

            case 1:
                // Walking up
                directionVector = Vector3.up;
                break;

            case 2:
                // Walking left
                directionVector = Vector3.left;
                break;

            case 3:
                // Walking down
                directionVector = Vector3.down;
                break;

            default:
                break;
        }

        UpdateAnimation();
    }

    // This code will update the animations when the NPC moves in a certain direction
    void UpdateAnimation()
    {
        animator.SetFloat("Move X", directionVector.x);
        animator.SetFloat("Move Y", directionVector.y);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Vector3 temp = directionVector;
        ChangeDirection();
        int loops = 0;
        
        while (temp == directionVector && loops < 100)
        {
            loops++;
            ChangeDirection();
        }
    }
}
