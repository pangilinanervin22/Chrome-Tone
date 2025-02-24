using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScriptLevels : MonoBehaviour
{
    public Button[] levelButtons;


    void Start()
    {
        for (int i = 0; i < levelButtons.Length; i++)
        {
            levelButtons[i].interactable = false;
        }
        for (int i = 0; i < PlayerPrefs.GetInt("levelAt"); i++)
        {
            levelButtons[i].interactable = true;
        }
    }


    public void OpenLevel(int level)
    {
        SceneManager.LoadSceneAsync("level " + level.ToString());
    }
}
