using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public string sceneToLoad;
    public Vector2 playerPosition;
    public VectorValue playerStorage;
    public GameObject transitionPanel;
    public GameObject transitionPanel2;
    public float fadeWait;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // This will control the transitions between scenes for the player
    private void Awake()
    {
        if (transitionPanel != null)
        {
            GameObject panel = Instantiate(transitionPanel, Vector3.zero, Quaternion.identity) as GameObject;
            Destroy(panel, 1);
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger)
        {
            playerStorage.initialValue = playerPosition;
            StartCoroutine(FadeCoroutine());
            //SceneManager.LoadScene(sceneToLoad);
        }
    }

    public IEnumerator FadeCoroutine()
    {
        if (transitionPanel != null)
        {
            Instantiate(transitionPanel2, Vector3.zero, Quaternion.identity);
        }

        // This will control how long the fading between scenes takes
        yield return new WaitForSeconds(fadeWait);
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneToLoad);
        while (!asyncOperation.isDone)
        {
            yield return null;
        }
    }
}
