using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SignBehavior : MonoBehaviour
{
    public GameObject messageBox;
    public Text messageText;
    public string message;
    public bool playerInRange;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // This code will bring up the message box if the player presses a certain key
        if (Input.GetKeyDown(KeyCode.Space) && playerInRange)
        {
            if (messageBox.activeInHierarchy)
            {
                messageBox.SetActive(false);
            }

            else
            {
                messageBox.SetActive(true);
                messageText.text = message;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // This code will check to see if the player is within range of the wooden sign
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        // This code will check to see if the player is not within range of the wooden sign
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            messageBox.SetActive(false);
        }
    }
}
