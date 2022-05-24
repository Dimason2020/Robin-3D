using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthBar : BaseSlider
{
    public static PlayerHealthBar Instance;

    public override void SetValue(int point)
    {
        if (point > 0)
            healthText.SetText(point.ToString());
        else
            healthText.SetText("0");

        slider.value = point;
        StartCoroutine(FillDamage());

    }

    protected override void Awake()
    {
        base.Awake();

        Instance = this;
    }
}
