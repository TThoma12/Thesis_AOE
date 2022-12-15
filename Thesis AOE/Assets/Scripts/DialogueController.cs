using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueController : MonoBehaviour
{
    public GameObject dialogueBox;
    public Text dialogueText;
    public List<string> Text = new List<string>();
    public bool playerInRange;
    public GameObject player;
    private int messageTrack = -1;
    private PlayerController2D playerController;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        playerController = player.GetComponent<PlayerController2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // This code will bring up the dialogue box if the player presses a certain key
        if (Input.GetKeyDown(KeyCode.Space) && playerInRange)
        {
            if (dialogueBox.activeInHierarchy && messageTrack == Text.Count - 1)
            {
                messageTrack = -1;
                Time.timeScale = 1;
                playerController.enabled = true;
                dialogueBox.SetActive(false);
            }

            else
            {
                Time.timeScale = 0;
                playerController.enabled = false;
                dialogueBox.SetActive(true);
                messageTrack++;
                dialogueText.text = Text[messageTrack];
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
