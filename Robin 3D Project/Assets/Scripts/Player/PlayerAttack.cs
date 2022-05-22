using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private Transform shootPoint;
    [SerializeField] private Projectile projectile;


    public void Attack()
    {
        Projectile arrow = Instantiate(projectile, 
            shootPoint.position, 
            shootPoint.rotation);

        arrow.SetProjectile(CharacterType.Enemy);
    }
}
