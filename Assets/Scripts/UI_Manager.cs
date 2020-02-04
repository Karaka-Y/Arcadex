using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_Manager : MonoBehaviour
{
    public Animator startButton;
    public Animator settingsButton;
    public Animator exitButton;
    public Animator dialog;
    public void StartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void SettingsOpen()
    {
        startButton.SetBool("isHidden", true);
        settingsButton.SetBool("isHidden", true);
        exitButton.SetBool("isHidden", true);
        dialog.SetBool("isHidden", false);
    }
    public void CloseSettings(){
        dialog.SetBool("isHidden", true);
        startButton.SetBool("isHidden", false);
        settingsButton.SetBool("isHidden", false);
        exitButton.SetBool("isHidden", false);
        
    }
}
