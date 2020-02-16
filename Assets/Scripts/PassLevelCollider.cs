using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassLevelCollider : MonoBehaviour
{
    // Start is called before the first frame update
    public LevelManager manager;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter2D (Collider2D other){
        isDestroyable target = other.GetComponent<isDestroyable>();
            if (target != null){
                manager.LevelCompleted();}
    }
}
