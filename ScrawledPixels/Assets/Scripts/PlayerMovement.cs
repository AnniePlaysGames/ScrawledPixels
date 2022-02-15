using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Animator))]

public class  PlayerMovement : MonoBehaviour
{
    [Range(1.0f,10.0f)]
    [SerializeField] private float _speed = 0.5f;
    private Rigidbody2D _rb;
    private Vector2 _currentDirection;
    private Vector2 _lastDirection;

    private Animator _animator;
    private int _verticalKey;
    private int _horizontalKey;
    private int _isMovingKey;
    private bool _isMoving;
    
    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        
        _animator = GetComponent<Animator>();
        _verticalKey = Animator.StringToHash("Vertical");
        _horizontalKey = Animator.StringToHash("Horizontal");
        _isMovingKey = Animator.StringToHash("IsMoving");
    }

    private void Update()
    {
        _isMoving = _currentDirection.magnitude > 0;
        AnimatonLogic();
    }

    private void FixedUpdate()
    {
        if (_isMoving) MoveLogic();
    }

    private void MoveLogic()
    {
        Vector2 currentPosition = _rb.position;
        Vector2 adjustedMovement = _currentDirection * _speed;
        Vector2 newPosition = currentPosition + adjustedMovement * Time.fixedDeltaTime;
        _rb.MovePosition(newPosition);
    }

    public void SetDirection(Vector2 direction)
    {
        _currentDirection = direction;
    }

    private void AnimatonLogic()
    {
        if (_isMoving)
        {
            _animator.SetBool(_isMovingKey, true);
            _animator.SetFloat(_horizontalKey, _currentDirection.x);
            _animator.SetFloat(_verticalKey, _currentDirection.y);
            _lastDirection = _currentDirection;
        }
        else
        {
            _animator.SetBool(_isMovingKey, false);
            _animator.SetFloat(_horizontalKey, _lastDirection.x);
            _animator.SetFloat(_verticalKey, _lastDirection.y);
        }
    }
}
