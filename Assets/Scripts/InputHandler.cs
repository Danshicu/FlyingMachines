using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler
{
    private Vector2 _mouseInput;
    private Vector2 _moveInput;
    public Vector2 MoveInput
    {
        get
        {
            HandleKeyInput();
            return _moveInput;
        }
    }

    public InputHandler()
    {
        _mouseInput = new Vector2();
        _moveInput = new Vector2();
    }

    private void HandleKeyInput()
    {
        _moveInput.x = Input.GetAxis("Horizontal");
        _moveInput.y = Input.GetAxis("Vertical");
    }
}
