using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseRangeBot : BaseBotAI
{
    [SerializeField] private GameObject arrowPrefab;
    [SerializeField] private Transform shootPoint;

    public void Shoot()
    {
        Instantiate(arrowPrefab,
            shootPoint.position,
            shootPoint.rotation);
    }

    protected override void Cooldown()
    {
        base.Cooldown();

        RotateToTarget();
    }
}
