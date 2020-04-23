using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;


//meneger class that controls health and level-finish UI, and characters die
public class LevelManager : MonoBehaviour
{   
    public Text livesLabel;
    public GameObject levelConditionPanel;
    public Text collectedCrystals;
    public int lives = 3;
    public GameObject defeatPanel;
    public GameObject victoryPanel;
    //public GameObject awarePanel;
    public GameObject character;
    // Start is called before the first frame update
    void Start()
    {
        //here we show choosen lives count in upper-left corner
        livesLabel.text = lives.ToString();

        //end deactivate (set initial state) other UI panels
        defeatPanel.SetActive(false);
        victoryPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("escape"))
            Application.Quit();
    }

    //this function calls when character collider interacts with other colliders of objects that have 'Hurt' component attached
    public void CharacterDestroyed(){
        //count of lives is decreased and shown in UI
        lives--;
        livesLabel.text = lives.ToString();

        //end if we have no more lives the defeat panel activates and character object sets as inactive
        if(lives == 0){
            defeatPanel.SetActive(true);
            character.SetActive(false);
        }
    }

    //if character reach the cup collider this function is called
    public void LevelCompleted(){

        //character deactivates and victory panel appears
        victoryPanel.SetActive(true);
        character.SetActive(false);
    }
    public void NotEnoughItems(int availableCount, int requiredCount){
        collectedCrystals.text = String.Format("Collect {0} more crystals to pass the level", requiredCount - availableCount);
        levelConditionPanel.SetActive(true);
    }

}
