using System;
using UnityEngine;

public class SpearmanBoss : Spearman
{
    public static SpearmanBoss Instance;
    private bool onArmorEnded;

    public Action OnArmorEnded;

    protected override void Awake()
    {
        base.Awake();

        Instance = this;
    }

    public override void GetDamage(int damagePoint)
    {
        base.GetDamage(damagePoint);

        if(armorPoint <= 0 && !onArmorEnded)
        {
            onArmorEnded = true;
            OnArmorEnded?.Invoke();
            ragdollController.ThrowArmor();
        }
    }

}
