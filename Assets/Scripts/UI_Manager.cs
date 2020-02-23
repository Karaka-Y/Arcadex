using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//this class controls main menu UI, and some in level-1 scene
public class UI_Manager : MonoBehaviour
{
    //we define references to all UI elemetns that we have in the scene
    public Animator gearAnimation;
    public Animator menuPanel;
    public Animator startButton;
    public Animator settingsButton;
    public Animator exitButton;
    public Animator dialog;

    //function that change scene from main memu to level scene
    public void StartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("SampleScene");
    }

    //function that load menu scene
    public void ExitToMainMenu(){
        UnityEngine.SceneManagement.SceneManager.LoadScene("TitleScene");
    }

    public void ExitGame(){
        Application.Quit();
    }


    //if we click 'Settings' button some animations transit will be triggered
    //all the buttons will move out of the visible scene
    //and dialogue panel will appear
    public void SettingsOpen()
    {
        startButton.SetBool("isHidden", true);
        settingsButton.SetBool("isHidden", true);
        exitButton.SetBool("isHidden", true);
        dialog.SetBool("isHidden", false);
    }

    //same function that reverts all changes of previous function
    public void CloseSettings(){
        dialog.SetBool("isHidden", true);
        startButton.SetBool("isHidden", false);
        settingsButton.SetBool("isHidden", false);
        exitButton.SetBool("isHidden", false);
        
    }
    //function for the level-1 scene, we get the current state of menu panel and change it to opposite by clicking menu button
    //also we want to start two animations when button is clicked so we change value for gear animation with panel
    public void ToggleMenu(){
        bool isHidden = menuPanel.GetBool("isHidden");
        menuPanel.SetBool("isHidden", !isHidden);
        gearAnimation.SetBool("isHidden", !isHidden);
    }

}
