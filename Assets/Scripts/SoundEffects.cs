using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using TMPro;
using UnityEngine.UI;
using System;
using UnityEngine.EventSystems; // Required when using Event data.
public class SoundEffects : MonoBehaviour
{
    public AudioSource Ui_ButtonHover;
    public AudioClip hoverEFX;

    public void Hover()
    {
        Ui_ButtonHover.PlayOneShot(hoverEFX);
    }
}
