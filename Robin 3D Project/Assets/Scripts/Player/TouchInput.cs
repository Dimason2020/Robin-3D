using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchInput : Singleton<TouchInput>
{
    public Joystick Stick { get => joystick; }
    private Joystick joystick;

    public override void Awake()
    {
        base.Awake();

        joystick = GetComponentInChildren<Joystick>();
    }
}
