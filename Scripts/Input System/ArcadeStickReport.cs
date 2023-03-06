using System.Runtime.InteropServices;
using UnityEngine.InputSystem.Layouts;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.InputSystem.Utilities;


[StructLayout(LayoutKind.Explicit,Size = 128)]//was 64
public struct ArcadeStickReport : IInputStateTypeInfo
{
    public FourCC format => new FourCC('H', 'I', 'D');

    [FieldOffset(0)] public byte reportId;

    [InputControl(name = "bluestick",offset = 1,layout = "Stick",format = "VEC2")]
    [InputControl(name="bluestick/up",offset = 1,format = "BIT",sizeInBits = 8,parameters = "normalize,normalizeZero=0.5,normalizeMin=0,normalizeMax=1,clamp,clampMin=0.5,clampMax=1")]
    [InputControl(name="bluestick/down",offset = 1,format = "BIT",sizeInBits = 8,parameters = "normalize,normalizeZero=0.5,normalizeMin=0,normalizeMax=1,invert,clamp,clampMin=0,clampMax=0.5")]
    [InputControl(name="bluestick/y",offset = 1,format="BYTE",sizeInBits = 8,parameters = "normalize,normalizeZero=0.5,normalizeMin=0,normalizeMax=1")]
    
    [InputControl(name="bluestick/left",offset = 0,format = "BIT",sizeInBits = 8,parameters = "normalize,normalizeZero=0.5,normalizeMin=0,normalizeMax=1,clamp,clampMin=0.5,clampMax=1")]
    [InputControl(name="bluestick/right",offset = 0,format = "BIT",sizeInBits = 8,parameters = "normalize,normalizeZero=0.5,normalizeMin=0,normalizeMax=1,invert,clamp,clampMin=0,clampMax=0.5")]
    [InputControl(name="bluestick/x",offset = 0,format="BYTE",sizeInBits = 8,parameters = "normalize,normalizeZero=0.5,normalizeMin=0,normalizeMax=1,invert")]
    
    [InputControl(name = "redstick",offset = 1,layout = "Stick",format = "VEC2")]
    [InputControl(name="redstick/left",offset = 1,format = "BIT",sizeInBits = 8,parameters = "normalize,normalizeZero=0.5,normalizeMin=0,normalizeMax=1,clamp,clampMin=0.5,clampMax=1")]
    [InputControl(name="redstick/right",offset = 1,format = "BIT",sizeInBits = 8,parameters = "normalize,normalizeZero=0.5,normalizeMin=0,normalizeMax=1,invert,clamp,clampMin=0,clampMax=0.5")]
    [InputControl(name="redstick/x",offset = 1,format="BYTE",sizeInBits = 8,parameters = "normalize,normalizeZero=0.5,normalizeMin=0,normalizeMax=1,invert")]
    
    [InputControl(name="redstick/down",offset = 0,format = "BIT",sizeInBits = 8,parameters = "normalize,normalizeZero=0.5,normalizeMin=0,normalizeMax=1,clamp,clampMin=0.5,clampMax=1")]
    [InputControl(name="redstick/up",offset = 0,format = "BIT",sizeInBits = 8,parameters = "normalize,normalizeZero=0.5,normalizeMin=0,normalizeMax=1,invert,clamp,clampMin=0,clampMax=0.5")]
    [InputControl(name="redstick/y",offset = 0,format="BYTE",sizeInBits = 8,parameters = "normalize,normalizeZero=0.5,normalizeMin=0,normalizeMax=1,invert")]

    [FieldOffset(0)]
    public byte stick;

    [InputControl(name = "oneplayer", layout = "Button", displayName = "1P", bit = 4)]
    [InputControl(name = "twoplayer", layout = "Button", displayName = "2P", bit = 5)]
    [InputControl(name = "redaction", layout = "Button", displayName = "Red Action", bit = 6)]
    [FieldOffset(6)] public byte buttonsA;
    [InputControl(name="blueaction",layout="Button",displayName = "Blue Action",bit = 7)]
    [FieldOffset(7)] public byte buttonsB;
}
