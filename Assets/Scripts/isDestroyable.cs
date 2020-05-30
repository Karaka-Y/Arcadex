using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//class that destroy our character when it collides with objects that have 'Hurt' component included
public class isDestroyable : MonoBehaviour
{
    public LevelManager manager;

    void OnTriggerEnter2D(Collider2D other){
            Hurt target = other.GetComponent<Hurt>();
            if (target != null){
                manager.CharacterDestroyed();
                    this.transform.SetPositionAndRotation( new Vector3(-3.07f, -0.994f, 0), other.transform.rotation);
            }
        }
}
