using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using TMPro;
using UnityEngine.UI;
using System;
public class SoundM : MonoBehaviour
{
    private static GameObject instance;
    public AudioSource BackGroundMusic;
    void Awake()
    {
        BackGroundMusic.Play();
        DontDestroyOnLoad(this.gameObject);
        if (instance == null)
        {
            instance = gameObject;
        }

        else
        {
            Destroy(gameObject);
        }


    }
}