using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class UI_Manager : MonoBehaviour
{
    public Animator gearAnimation;
    public Animator menuPanel;
    public Animator startButton;
    public Animator settingsButton;
    public Animator exitButton;
    public Animator dialog;
    public void StartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("SampleScene");
    }
    public void ExitToMainMenu(){
        UnityEngine.SceneManagement.SceneManager.LoadScene("TitleScene");
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
    public void ToggleMenu(){
        bool isHidden = menuPanel.GetBool("isHidden");
        menuPanel.SetBool("isHidden", !isHidden);
        gearAnimation.SetBool("isHidden", !isHidden);
    }

}
