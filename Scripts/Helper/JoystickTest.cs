using System;
using System.Collections;
using System.Collections.Generic;
using ArcadeCabinet;
using UnityEngine;
using UnityEngine.InputSystem;

public class JoystickTest : MonoBehaviour
{
    public Vector2 stick;
    private PlayerInputDeviceSetter _playerInputSetter;

    private bool inputEnabled;
    //This example will use the PlayerInput behaviour "Invoke Unity Events".

    private void Awake()
    {
        _playerInputSetter = GetComponent<PlayerInputDeviceSetter>();
        inputEnabled = false;
    }


    public void OnAction(InputValue value)
    {
        //We don't need to wait for Assigned yet, because blue will only ever receive blue.
        
        Debug.Log($"{gameObject.name} Action!");
    }

    public void OnMove(InputValue value)
    {
        if (!_playerInputSetter.PlayerHasBeenAssigned)
        {
            //leave if we don't have the controller yet, because it could be invalid joystick data from other input.
            return;
        }
        
        stick = value.Get<Vector2>();
        Debug.Log($"{gameObject.name} Move {stick}");
    }
    public void OnOnePlayer(InputValue value)
    {
        //We don't need to wait for Assigned yet, because blue will only ever receive blue.
        Debug.Log($"1P");
    }
    
    public void OnTwoPlayer(InputValue value)
    {
        //We don't need to wait for Assigned yet, because blue will only ever receive blue.
        Debug.Log($"2P");
    }
}
