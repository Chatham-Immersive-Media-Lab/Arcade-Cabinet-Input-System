#define DEBUG_VERBOSE

using System;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using ArcadeCabinet;
namespace ArcadeCabinet
{
    public class PlayerInputDeviceSetter : MonoBehaviour
    {
        public Action PlayerSuccesfullyAssignedDevice;
        public JoystickColor color;
        private PlayerInput _playerInput;
        private InputAction detectBlue;
        private InputAction detectRed;
        
        public bool PlayerHasBeenAssigned => _playerHasBeenAssigned;
        private bool _playerHasBeenAssigned = false;
        //Config
        private const string blueControlSchemeName = "Blue";
        private const string redControlSchemeName = "Red";
        //
        private void Awake()
        {
            _playerHasBeenAssigned = false;
            
            _playerInput = GetComponent<PlayerInput>();
            //override bad config
            _playerInput.neverAutoSwitchControlSchemes = true;
        }

        private void OnEnable()
        {
            if (color == JoystickColor.Blue)
            {
                detectBlue = new InputAction(binding: "<ArcadeStickHID>/blueaction");
                detectBlue.Enable();
            }else if (color == JoystickColor.Red)
            {
                detectRed = new InputAction(binding: "<ArcadeStickHID>/redaction");
                // detectRed.AddBinding();//todo: add 1p and 2p bindings for the input to detect which player is red.
                
                detectRed.Enable();
            }
        }


        private void Start()
        {
           
        }

        private void Update()
        {
            if (color == JoystickColor.Red && detectRed.IsPressed())
            {
                FindRedControl();
            }else if (color == JoystickColor.Blue && detectBlue.IsPressed())
            {
                FindBlueControl();
            }
        }

        void FindRedControl()
        {
            var sticks = InputSystem.FindControls("<ArcadeStickHID>");
            foreach (InputDevice device in sticks)
            {
                foreach (var c in device.allControls)
                {
                    //this action is called when ANY redaction happened on ANY device. So we find the device that pressed it.
                    if (c.IsPressed() && c.name == "redaction")
                    {
                        #if DEBUG_VERBOSE
                        Debug.Log("Switching Red player to red input device: "+device.name);
                        #endif
                        
                        _playerInput.SwitchCurrentControlScheme(redControlSchemeName,device);
                        detectRed.Disable();
                        detectRed.Dispose();
                        _playerHasBeenAssigned = true;
                        PlayerSuccesfullyAssignedDevice?.Invoke();
                    }
                }
            }
            sticks.Dispose();
        }
        void FindBlueControl()
        {
            var sticks = InputSystem.FindControls("<ArcadeStickHID>");
            foreach (InputDevice device in sticks)
            {
                foreach (var c in device.allControls)
                {
                    if (c.IsPressed() && c.name == "blueaction")
                    {
#if DEBUG_VERBOSE
                        Debug.Log("Switching Blue player to blue input device: "+device.name);
#endif
                        _playerInput.SwitchCurrentControlScheme(blueControlSchemeName,device);
                        
                        //cleanup
                        detectBlue.Disable();
                        detectBlue.Dispose();
                        
                        //alert
                        _playerHasBeenAssigned = true;
                        PlayerSuccesfullyAssignedDevice?.Invoke();
                    }
                }
            }
            sticks.Dispose();
        }
    }
}