using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class LevelManager : MonoBehaviour
{   public bool characterDie = false;
    public Text livesLabel;
    public int lives = 3;
    // Start is called before the first frame update
    void Start()
    {
        livesLabel.text = lives.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void CharacterDestroyed(){
        lives--;
        livesLabel.text = lives.ToString();
        if(lives == 0){
            characterDie = true;
        }
    }

}
