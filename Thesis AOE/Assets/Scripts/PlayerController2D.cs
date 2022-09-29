using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2D : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb2d;
    
    //This script will be responsible for changing the player's position
    private Vector3 posChange;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        posChange = Vector3.zero;
        posChange.x = Input.GetAxisRaw("Horizontal");
        posChange.y = Input.GetAxisRaw("Vertical");

        //This script will allow the player to move in all four directions
        if (posChange != Vector3.zero)
        {
            MoveCharacter();
        }
    }

    void MoveCharacter()
    {
        rb2d.MovePosition(transform.position + posChange * speed * Time.deltaTime);
    }
}
