using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2D : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb2d;
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
        posChange.y = Input.GetAxis("Vertical");
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
