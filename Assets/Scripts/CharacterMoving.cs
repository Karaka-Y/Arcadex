using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMoving : MonoBehaviour
{   
    public float speed = 500f; 
    private Animator _anim;
    private Rigidbody2D _body;
    private BoxCollider2D _box;
    public float jumpForce = 3.0f;
    
    void Start()
    {
        Application.targetFrameRate = 60;
        _body = GetComponent<Rigidbody2D>(); 
        _anim = GetComponent<Animator>();
        _box = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        //get player input to move character by changing velocity of the rigidbody component
        float deltaX = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        Vector2 movement = new Vector2 (deltaX, _body.velocity.y);
        _body.velocity = movement;

        //check if the player is on the ground
        Vector3 max = _box.bounds.max;
        Vector3 min = _box.bounds.min;
        Vector2 Corner1 = new Vector2(max.x, min.y - 0.1f);
        Vector2 Corner2 = new Vector2(min.x, min.y - .2f);
        Collider2D hit = Physics2D.OverlapArea(Corner1, Corner2);
        bool isGrounded = false;
        if(hit != null){
            isGrounded = true;
        }

        //jump
        if(isGrounded && Input.GetKeyDown(KeyCode.Space)){

            _body.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }

        //make platform transform as a parent for character's transform when stay on platform
        MovingPlatform platform = null;
        if (hit != null){

            platform = hit.GetComponent<MovingPlatform>();
        }

        if(platform != null){
            transform.parent = platform.transform;
        }

        else {
            transform.parent = null;
        }
         
        //control for animation of moving
        _anim.SetFloat("speed", Mathf.Abs(deltaX));

        //change player sprite direction based of moving direction
        transform.localScale = new Vector3 (Mathf.Sign(deltaX), 1, 1);
    }
}
