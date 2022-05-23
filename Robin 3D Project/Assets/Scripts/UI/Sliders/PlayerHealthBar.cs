using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthBar : BaseSlider
{
    public static PlayerHealthBar Instance;

    protected override void Awake()
    {
        base.Awake();

        Instance = this;
    }
}
