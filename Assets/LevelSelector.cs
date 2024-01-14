using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelector : MonoBehaviour
{
    public Button[] levelButtons;
    int levelAt;
    void Start()
    {
         levelAt = PlayerPrefs.GetInt("levelAt", 2);
        for (int i = 0; i < levelButtons.Length; i++)
        {
            if (i + 2 > levelAt)
            {
                levelButtons[i].interactable = false;
                levelAt++;
            }
        }
    }
    void Update() {
        if (Input.GetKeyDown(KeyCode.F))
        {
            PlayerPrefs.SetInt("levelAt", 2);
            SceneManager.LoadScene(0);
        }
        
    }
}

        