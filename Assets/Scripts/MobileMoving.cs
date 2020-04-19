using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileMoving : MonoBehaviour
{   
    private BoxCollider2D _charCollider;
    private int _characterLookDir = 1;
    private Animator _anim;
    public bool moving;
    private int direction;
    public float speed = 500f;
    public Rigidbody2D _charBody;
    public float jumpForce = 11.0f;
    private bool jumping = false;
    // Start is called before the first frame update
    void Start()
    {
        _anim = GetComponent<Animator>();
        _charCollider = GetComponent<BoxCollider2D>();
        _charBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {   
        if(moving == true){
            _charBody.velocity = new Vector2(direction * speed * Time.deltaTime, _charBody.velocity.y);
        }
        _anim.SetFloat("speed", Mathf.Abs(_charBody.velocity.x));
        transform.localScale = new Vector3 (_characterLookDir, 1, 1);
        if(CharacterMoving.GroundCheck(_charCollider) && jumping == true){
            jumping = false;
            _charBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }
    public void RightButtonPressed()
    {
        if(moving == false)
        {
            direction = 1;
            moving = true;
        }
        _characterLookDir = 1;
    }
    public void RightButtonReleased()
    {   
            direction = 0;
            moving = false;
    }
    public void LeftButtonPressed()
    {
        if(moving == false)
        {
            direction = -1;
            moving = true;
        }
        _characterLookDir = -1;
    }
    public void LeftButtonReleased()
    {
        direction = 0;
        moving = false;
    }
    public void Jumping()
    {
        jumping = true;
    }
}
