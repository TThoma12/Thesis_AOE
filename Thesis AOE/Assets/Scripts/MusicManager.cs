using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public static MusicManager instance;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // This code will allow the music to keep playing between scenes
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);

        // This code will prevent the game object from duplicating between scenes
        if (instance == null)
        {
            instance = this;
        }

        else
        {
            Destroy(gameObject);
        }
    }
}
