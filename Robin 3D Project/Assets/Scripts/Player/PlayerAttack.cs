using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private Transform shootPoint;
    [SerializeField] private Projectile projectile;

    private Player player;
    private MainCharacterData characterData;


    private void Awake()
    {
        player = GetComponent<Player>();

        characterData = player.Data;
    }

    public void Shoot()
    {
        Projectile arrow = Instantiate(projectile, 
            shootPoint.position, 
            shootPoint.rotation);

        arrow.SetProjectile(CharacterType.Enemy, characterData.attackPoint);
    }
}
