using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScriptMenu : MonoBehaviour
{

    // Start is called before the first frame update
    public GameObject menu;

    void Awake()
    {
        menu.SetActive(false);
        Time.timeScale = 1;
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadSceneAsync("start");
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void PlayGame()
    {
        SceneManager.LoadSceneAsync("Level 1");
    }

    public void MenuShow()
    {
        Time.timeScale = 0;
        menu.SetActive(true);
    }

    public void MenuExit()
    {
        Time.timeScale = 1;
        menu.SetActive(false);
    }


    public void RestartGame()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }

    public void Home()
    {
        SceneManager.LoadSceneAsync("Start");
    }

}
