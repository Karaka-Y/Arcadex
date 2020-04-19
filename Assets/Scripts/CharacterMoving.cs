using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMoving : MonoBehaviour
{   
    public bool movingRight;
    private bool jumping = false;
    public float speed = 500f; 
    private Animator _anim;
    private Rigidbody2D _body;
    private BoxCollider2D _box;
    public float jumpForce = 3.0f;
    // Start is called before the first frame update
    void Start()
    {
        //if we want to use components' properties, we have to make sure that they are attached to GameObject
        _body = GetComponent<Rigidbody2D>(); 
        _anim = GetComponent<Animator>();
        _box = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {

        //used player input ('A', 'D' or arrow buttons) multiplied by speed and Time.deltatime (to make moving frame independent)
        float deltaX = Input.GetAxis("Horizontal") * speed * Time.deltaTime;

        //Vector2 represent character's moving (we move only in X, Y axises), now only in Y axis, becouse character moves in X axis
        //only when jumping
        Vector2 movement = new Vector2 (deltaX, _body.velocity.y);

        //movement vector is assigned to rigidbody2D component, so character moves
        _body.velocity = movement;

        // bounds are used as a part of character's jumping, character is not allowed to jump pushing off air, so
        // it will check if the ground is below the character

        //bounds represent coordinates of maximum and minimum values of characters collider
        //max.x is the maximum X value of box - the right edge of it
        //min x is the values of left age of square
        Vector3 max = _box.bounds.max;
        Vector3 min = _box.bounds.min;

        //little box was maded under the character using indentations from bounds values
        Vector2 Corner1 = new Vector2(max.x, min.y - 0.1f);
        Vector2 Corner2 = new Vector2(min.x, min.y - .2f);

        //OverlapArea shows us if the any collider interact with the area that falls into choosen rectangle
        //our rectangle is implemented by two corners that represents the upper-right corner and lower-left.
        //when character stays on the ground the tilemap collider falls into rectangle and we get it returned
        Collider2D hit = Physics2D.OverlapArea(Corner1, Corner2);

        //variable that controls jumping permission
        bool isGrounded = false;

        //if we get collider under character we get allow to jump
        if(hit != null){
            isGrounded = true;
        }

        //when we allowed to jump and 'Space' is pressed - we jump
        if(isGrounded && Input.GetKeyDown(KeyCode.Space)){
            jumping = false;
            //we add impulse to the character that throw it up in the air
            _body.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }

        //used variable to recognize object under the character, here we recognize definitely moving platform tilemap
        MovingPlatform platform = null;
        if (hit != null){

            //if collider has 'MovingPlatform' component (here it is the attached script) we ataching it to it's variable
            platform = hit.GetComponent<MovingPlatform>();
        }


        //we make platform's transform as a parent of character transform, so character will move with platform
        if(platform != null){
            transform.parent = platform.transform;
        }

        //when we jump out from the platform we reset character transform
        else {
            transform.parent = null;
        }
        
        //SetFloat allows us to set 'speed' value and make transition between animation clips
        //if 'speed' is higher than 1 - moving animation is played, if less then one - idle animation
        //Mathf.Abs is used becouse deltaX can be a negative when moving to the left. 
        _anim.SetFloat("speed", Mathf.Abs(deltaX));

        //here is a trick to reflct our character and make it being turned left
        transform.localScale = new Vector3 (Mathf.Sign(deltaX), 1, 1);
    }

}
