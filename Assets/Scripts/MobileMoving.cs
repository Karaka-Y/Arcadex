using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileMoving : MonoBehaviour
{   
    public bool moving;
    private int direction;
    public float speed = 500f;
    public Rigidbody2D _charBody;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   
        if(moving == true){
            _charBody.AddForce(new Vector2(direction * speed * Time.deltaTime, 0));
        }
        
    }
    public void RightButtonPressed()
    {
        direction = 1;
        moving = true;
    }
    public void RightButtonReleased()
    {   
        direction = 0;
        moving = false;
    }
}
