using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseRangeBot : BaseBotAI
{
    [SerializeField] private Projectile arrowPrefab;
    [SerializeField] private Transform shootPoint;

    public void Shoot()
    {
        Projectile arrow = Instantiate(arrowPrefab,
            shootPoint.position,
            shootPoint.rotation);

        arrow.SetProjectile(CharacterType.Friend);
    }

    protected override void Cooldown()
    {
        base.Cooldown();

        RotateToTarget();
    }
}
