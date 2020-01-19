using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_Manager : MonoBehaviour
{
    public Animator startButton;
    public Animator settingsButton;
    public Animator exitButton;
    public void StartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void SettingsOpen()
    {
        startButton.SetBool("isHidden", true);
        settingsButton.SetBool("isHidden", true);
        exitButton.SetBool("isHidden", true);
    }
}
