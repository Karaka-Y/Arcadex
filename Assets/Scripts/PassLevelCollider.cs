using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this class is used only to notify the level manager that character reached the end level Cup
public class PassLevelCollider : MonoBehaviour
{
    //reference to the level manager
    public LevelManager manager;

    //finish cup has a box collider that behave as a trigger
    //when other collider interact with it, we check if the collider owner has a isDestroyable component
    //to make sure that it is a character
    public void OnTriggerEnter2D (Collider2D other){
        isDestroyable target = other.GetComponent<isDestroyable>();
            if (target != null){
                //if character reacted with cup collider, we call end-level-function
                manager.LevelCompleted();}
    }
}
