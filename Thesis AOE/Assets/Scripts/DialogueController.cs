using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueController : MonoBehaviour
{
    public GameObject dialogueBox;
    public Text dialogueText;
    public string message;
    public bool playerInRange;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // This code will bring up the dialogue box if the player presses a certain key
        if (Input.GetKeyDown(KeyCode.Space) && playerInRange)
        {
            if (dialogueBox.activeInHierarchy)
            {
                dialogueBox.SetActive(false);
            }

            else
            {
                dialogueBox.SetActive(true);
                dialogueText.text = message;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // This code will check to see if the player is within range of an NPC
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        // This code will check to see if the player is not within range of the NPC
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            dialogueBox.SetActive(false);
        }
    }
}
