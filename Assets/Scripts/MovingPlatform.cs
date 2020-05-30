using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//class that moves platform
public class MovingPlatform : MonoBehaviour
{
    public Vector3 finishPos = Vector3.zero;
    public float speed = 0.5f;

    private Vector3 _startPos;
    private float _trackPercent = 0;
    private int _direction = 1;
    void Start()
    {
        _startPos = transform.position;
    }

    void Update()
    {
        //after one second trackPercent will equal to 0,5 (-0,5) or half of distance that platform should pass
        _trackPercent += _direction * speed * Time.deltaTime;
        float x = (finishPos.x - _startPos.x) * _trackPercent + _startPos.x;
        float y = (finishPos.y - _startPos.y) * _trackPercent + _startPos.y;
        
        transform.position = new Vector3(x,y,_startPos.z);

        //when trackpercent = 1 (platform have passed full distance) it's direction will be changed to opposite
        if ((_direction == 1 && _trackPercent >= 1f) || (_direction == -1 && _trackPercent <= 0f)){
            _direction *= -1;
        }
        
    }
}
