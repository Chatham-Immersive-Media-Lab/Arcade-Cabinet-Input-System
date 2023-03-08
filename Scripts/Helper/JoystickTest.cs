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

    //This example will use the PlayerInput behaviour "Invoke Unity Events".

    //Note that Red's input has been inverted in the ActionMap setup.
    //We shouldn't have to do anything here, and up and down are perspective correct for this example.
    //Depending on the game, you may or may not want that. I think it's best to do it there.
    //In other words, Player code, like this example, should be as ambivalent to which-player-am-I as possible.
    
    //The OnAction calls are called by the playerInput Script.
    private void Awake()
    {
        _playerInputSetter = GetComponent<PlayerInputDeviceSetter>();
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
    }
    
    //only CAN get called for red
    public void OnOnePlayer(InputValue value)
    {
        Debug.Log($"1P");
    }
    
    //also only can be called for red
    public void OnTwoPlayer(InputValue value)
    {
        Debug.Log($"2P");
    }


    void Update()
    {
        transform.Translate(stick*Time.deltaTime*5);
    }
}
