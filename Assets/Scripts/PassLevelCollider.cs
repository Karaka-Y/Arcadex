using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this class is used only to notify the level manager that character reached the end level Cup
public class PassLevelCollider : MonoBehaviour
{
    
    public LevelManager manager;
    public void OnTriggerEnter2D (Collider2D other){
        isDestroyable target = other.GetComponent<isDestroyable>();
            if (target != null){
                manager.LevelCompleted();}
    }
}
