using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hurt : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other){
            isDestroyable target = other.GetComponent<isDestroyable>();
            if (target != null){
                other.transform.SetPositionAndRotation( new Vector3(-3.07f, -0.994f, 0), other.transform.rotation);
            }
        }
}
