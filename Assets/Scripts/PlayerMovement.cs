using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

[RequireComponent(typeof(Rigidbody))]

public class PlayerMovement : MonoBehaviour
{
    private PlayerInputActions _playerInputActions;
    
    [Header("Moving")]
    [SerializeField] private float positiveMaxSpeed;
    [SerializeField] private float negativeMaxSpeed;
    [SerializeField] private float speedIncreasingRate;
    [SerializeField] private float speedDecreasingRate;
    private bool _isMoving;
    
    [Header("Stop moving")]
    [SerializeField] private float dampingSpeedFactor=0.9f;
    [SerializeField] private float minimalMovingSpeed;
   
    [Header("Physical stats")] 
    [SerializeField] private float forceMultiplayer;
    
    [Header("Rotating")] 
    [SerializeField] private Vector3 rotationSpeed;
    
    [Header("Debug")]
    [SerializeField] private float currentSpeed;
    
    //private InputHandler _inputHandler = new InputHandler();
    private Rigidbody _rigidbody;
    private Vector2 _moveInput;
    private Vector2 _lookUpInput;

    public void GetInputListener(PlayerInputActions inputActions)
    {
        _playerInputActions = inputActions;
        MakeSubscriptions();
    }

    private void MakeSubscriptions()
    {
        _playerInputActions.InMatchInput.Enable();
        _playerInputActions.InMatchInput.Movement.performed += ChangeMovingState;
        _playerInputActions.InMatchInput.Movement.canceled += ChangeMovingState;
        _playerInputActions.InMatchInput.LookUp.performed += ReadLookUp;
    }

    private void ReadLookUp(InputAction.CallbackContext context)
    {
        //_lookUpInput = context.ReadValue<Vector2>();
    }

    private void ChangeMovingState(InputAction.CallbackContext context)
    {
        if (context.canceled)
        {
            _isMoving = false;
            _moveInput = Vector2.zero;
            return;
        }
        _isMoving = true;
    }

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
    }
    
    private void FixedUpdate()
    {
        if (_isMoving)
        {
            _moveInput = _playerInputActions.InMatchInput.Movement.ReadValue<Vector2>();
        }
        ChangeSpeed(_moveInput.y);
        _lookUpInput = _playerInputActions.InMatchInput.LookUp.ReadValue<Vector2>();
        _rigidbody.AddForce(transform.forward * currentSpeed * forceMultiplayer  * Time.fixedDeltaTime, ForceMode.VelocityChange);
        _rigidbody.AddRelativeTorque(Vector3.Scale(new Vector3(-_lookUpInput.y, _lookUpInput.x, -_moveInput.x), rotationSpeed*Time.fixedDeltaTime), ForceMode.VelocityChange);
        
    }

    private void ChangeSpeed(float direction)
    {
        switch (direction)
        {
            case >0: currentSpeed += direction * speedIncreasingRate;
                break;
            case <0: currentSpeed += direction * speedDecreasingRate;
                break;
            default: currentSpeed *= dampingSpeedFactor;
                break;
        }
        currentSpeed = Math.Clamp(currentSpeed, -negativeMaxSpeed, positiveMaxSpeed);

        if (Math.Abs(currentSpeed) < minimalMovingSpeed)
        {
            currentSpeed = 0;
        }
        
    }
    
}
