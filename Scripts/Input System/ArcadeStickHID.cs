using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Layouts;
using UnityEngine.InputSystem.LowLevel;

namespace ArcadeCabinet
{
    [InputControlLayout(stateType = typeof(ArcadeStickReport))]
    #if UNITY_EDITOR
    [InitializeOnLoad]
    #endif
    public class ArcadeStickHID : Joystick
    {
        public InputDevice maskDevice;
        static ArcadeStickHID()
        {
            InputSystem.RegisterLayout<ArcadeStickHID>(
                matches: new InputDeviceMatcher()
                    .WithInterface("HID")
                    // .WithCapability("vendorID",0x79)
                    // .WithCapability("productID",0x6)
                    .WithManufacturer("DragonRise Inc. ")
                    // .WithCapability("usage",4)
                    // .WithCapability("usagePage","GenericDesktop")
                );
        }
        [RuntimeInitializeOnLoadMethod]
        static void Init(){}

        
    }
}