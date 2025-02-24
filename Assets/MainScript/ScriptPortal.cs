using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScriptPortal : MonoBehaviour
{
    private bool isWhite = false;
    private bool isBlack = false;
    // Start is called before the first frame update
    private void FixedUpdate()
    {
        transform.Rotate(0, 0, 1);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "WhiteCharacter")
        {
            isWhite = true;
            ScriptSoundManager.instance.PlayTeleportSound();
        }
        else if (other.gameObject.name == "BlackCharacter")
        {
            isBlack = true;
            ScriptSoundManager.instance.PlayTeleportSound();
        }

        Destroy(other.gameObject);

        int currentLevel = SceneManager.GetActiveScene().buildIndex;
        PlayerPrefs.SetInt("levelAt", currentLevel + 1);
        if (currentLevel >= 10 && isWhite && isBlack)
            SceneManager.LoadSceneAsync("Start");
        else if (isWhite && isBlack)
            SceneManager.LoadSceneAsync("Level " + (currentLevel + 1).ToString());
    }
}
