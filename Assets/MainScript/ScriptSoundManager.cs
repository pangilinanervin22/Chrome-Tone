using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptSoundManager : MonoBehaviour
{
    public static ScriptSoundManager instance { get; private set; }
    public AudioClip deathSound;
    public AudioClip backgroundMusic;
    public AudioClip teleportSound;
    private AudioSource audioSource;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        if (instance == null)
        {
            instance = this;
            audioSource = GetComponent<AudioSource>();
            Application.targetFrameRate = 60;
            PlayBackgroundMusic();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlaySound(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }

    public void PlayTeleportSound()
    {
        audioSource.PlayOneShot(teleportSound);
    }

    public void PlayBackgroundMusic()
    {
        audioSource.clip = backgroundMusic;
        audioSource.loop = true;
        audioSource.Play();
    }

    public void PlayDeathSound()
    {
        audioSource.PlayOneShot(deathSound);
    }
}
