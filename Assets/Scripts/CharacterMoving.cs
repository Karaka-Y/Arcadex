using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMoving : MonoBehaviour
{   
    public float speed = 500f;
    private Animator _anim;
    private Rigidbody2D _body;

    public float jumpForce = 3.0f;
    // Start is called before the first frame update
    void Start()
    {
        _body = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        float deltaX = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        Vector2 movement = new Vector2 (deltaX, _body.velocity.y);
        _body.velocity = movement;

        if(Input.GetKeyDown(KeyCode.Space)){
            _body.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
        _anim.SetFloat("speed", Mathf.Abs(deltaX));
        transform.localScale = new Vector3 (Mathf.Sign(deltaX), 1, 1);
    }
}
