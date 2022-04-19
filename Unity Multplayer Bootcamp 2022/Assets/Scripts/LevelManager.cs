using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager mInstance;

    private void Awake()
    {
        if (!mInstance)
        {
            mInstance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(mInstance);
        }
    }

    public void OnAuthenticationComplete()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
