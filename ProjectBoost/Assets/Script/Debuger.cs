using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Debuger : MonoBehaviour
{
    CollisionHandler collisionHandler;
    void Start()
    {
        collisionHandler = GetComponent<CollisionHandler>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            Debug.Log("Load Next Scene");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else if (Input.GetKeyDown(KeyCode.P))
        {
            Debug.Log("Load Prev Scene");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
        else if (Input.GetKeyDown(KeyCode.C))
        {
            collisionHandler.CollisionHandlerControl();
        }
    }
}
