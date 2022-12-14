using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundedNPC : MonoBehaviour
{
    private Vector3 directionVector;
    private Transform myTransform;
    public float walkSpeed;
    private Rigidbody2D rb2d;

    // Start is called before the first frame update
    void Start()
    {
        myTransform = GetComponent<Transform>();
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        rb2d.MovePosition(myTransform.position + directionVector * walkSpeed * Time.deltaTime);
    }

    void ChangeDirection()
    {
        int direction = Random.Range(0, 4);
        switch (direction)
        {
            case 0:
                // Walking to the right
                directionVector = Vector3.right;
                break;

            case 1:
                // Walking upwards
                directionVector = Vector3.up;
                break;

            case 2:
                // Walking to the left
                directionVector = Vector3.left;
                break;

            case 3:
                // Walking downwards
                directionVector = Vector3.down;
                break;

            default:
                break;
        }
    }
}
