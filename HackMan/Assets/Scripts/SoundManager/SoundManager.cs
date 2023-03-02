using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip attackSound, clickSound, hurtSound, dieSound, points_UPsound, gameOverSound, levelCompleteSound;
    static AudioSource myAudioSource;

    private void Awake()
    {
        SetUpSingleton();
    }

    private void SetUpSingleton()
    {
        int numberSoundManager = FindObjectsOfType<SoundManager>().Length;

        if (numberSoundManager > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        attackSound = Resources.Load<AudioClip>("Attack");
        clickSound = Resources.Load<AudioClip>("Click");
        hurtSound = Resources.Load<AudioClip>("Hurt");
        dieSound = Resources.Load<AudioClip>("Die");
        points_UPsound = Resources.Load<AudioClip>("Points_Up");
        gameOverSound = Resources.Load<AudioClip>("Game_Over");
        levelCompleteSound = Resources.Load<AudioClip>("Level_Complete");

        myAudioSource = GetComponent<AudioSource>();
    }

    public static void PlaySound(string clip)
    {
        switch(clip)
        {
            case "Attack":
                myAudioSource.PlayOneShot(attackSound);
                break;

            case "Click":
                myAudioSource.PlayOneShot(clickSound);
                break;

            case "Hurt":
                myAudioSource.PlayOneShot(hurtSound);
                break;

            case "Die":
                myAudioSource.PlayOneShot(dieSound);
                break;

            case "Points_Up":
                myAudioSource.PlayOneShot(points_UPsound);
                break;

            case "Game_Over":
                myAudioSource.PlayOneShot(gameOverSound);
                break;

            case "Level_Complete":
                myAudioSource.PlayOneShot(levelCompleteSound);
                break;
        }
    }
}
