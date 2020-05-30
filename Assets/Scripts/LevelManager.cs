using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;


//meneger class that controls health and level-finish UI, and characters die
public class LevelManager : MonoBehaviour
{   
    public Text livesLabel;
    public int lives = 3;
    public GameObject defeatPanel;
    public GameObject victoryPanel;
    public GameObject character;

    void Start()
    {
        livesLabel.text = lives.ToString();
        defeatPanel.SetActive(false);
        victoryPanel.SetActive(false);
    }
    void Update()
    {
        if (Input.GetKey("escape"))
            Application.Quit();
    }

    //this function calls when character collider interacts with other colliders of objects that have 'Hurt' component attached
    public void CharacterDestroyed(){
        lives--;
        livesLabel.text = lives.ToString();

        if(lives == 0){
            defeatPanel.SetActive(true);
            character.SetActive(false);
        }
    }

    //if character reach the cup collider this function is called
    public void LevelCompleted(){
        victoryPanel.SetActive(true);
        character.SetActive(false);
    }

}
