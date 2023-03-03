using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSFX : MonoBehaviour
{
    public AudioSource mySFX;
    public AudioClip hoverButton;
    public AudioClip clickButton;

    public void HoverButton()
    {
        mySFX.PlayOneShot(hoverButton);
    }

    public void ClickButton()
    {
        mySFX.PlayOneShot(clickButton);
    }
}
