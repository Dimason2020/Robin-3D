using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseMeleeBot : BaseBotAI
{
    [SerializeField] private MeleeWeapon meleeWeapon;

    protected override void Awake()
    {
        base.Awake();

        meleeWeapon = GetComponentInChildren<MeleeWeapon>();
    }

    protected override void StartAttack()
    {
        base.StartAttack();

        meleeWeapon.EnableCollider();
    }
}
