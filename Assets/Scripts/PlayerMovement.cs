using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[RequireComponent(typeof(Rigidbody))]

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float positiveMaxSpeed;
    [SerializeField] private float negativeMaxSpeed;
    [SerializeField] private float speedIncreasingRate;
    [SerializeField] private float speedDecreasingRate;
    [SerializeField] private float dampingSpeedFactor=0.9f;
    [SerializeField] private float minimalMovingSpeed;
    [SerializeField] private float currentSpeed;
    private InputHandler _inputHandler = new InputHandler();
    private Rigidbody _rigidbody;

    private void OnEnable()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Vector2 moveInput = _inputHandler.MoveInput;
        ChangeSpeed(moveInput.y);
        _rigidbody.AddForce(transform.forward * currentSpeed);
        
    }

    private void ChangeSpeed(float direction)
    {
        currentSpeed *= dampingSpeedFactor;
        switch (direction)
        {
            case >0: currentSpeed += direction * speedIncreasingRate * Time.fixedDeltaTime;
                break;
            case <0: currentSpeed += direction * speedDecreasingRate * Time.fixedDeltaTime;
                break;
        }
        currentSpeed = Math.Clamp(currentSpeed, negativeMaxSpeed, positiveMaxSpeed);

        if (Math.Abs(currentSpeed) < minimalMovingSpeed)
        {
            currentSpeed = 0;
        }
        
    }
    
}
