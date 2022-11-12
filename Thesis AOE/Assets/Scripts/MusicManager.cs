using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // This code will allow the music to keep playing between scenes
    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }
}
