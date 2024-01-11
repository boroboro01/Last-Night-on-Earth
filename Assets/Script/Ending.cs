using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ending : MonoBehaviour
{
        void Start()
    {
        StartCoroutine(EndingWaiting());
    }
    IEnumerator EndingWaiting()
            {
                yield return new WaitForSeconds(30.0f);
                SceneManager.LoadScene(0);
            }
}

