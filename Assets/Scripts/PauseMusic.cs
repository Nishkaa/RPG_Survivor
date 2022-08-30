using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using TMPro;
using UnityEngine.UI;
using System;
public class PauseMusic : MonoBehaviour
{
    public void Update()
    {

        if (SceneManager.GetActiveScene().name == "SceneOne")
        {
            SoundM.instance.GetComponent<AudioSource>().Pause();
        }
        if (SceneManager.GetActiveScene().name == "SceneTwo")
        {
            SoundM.instance.GetComponent<AudioSource>().Pause();
        }
    }
}
