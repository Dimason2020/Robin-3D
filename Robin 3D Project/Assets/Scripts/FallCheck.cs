using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallCheck : MonoBehaviour
{
    private Player player;
    private Transform playerPosition;

    private void Start()
    {
        player = Player.Instance;
        playerPosition = player.transform;

        StartCoroutine(CheckPlayerPosition());
    }

    private IEnumerator CheckPlayerPosition()
    {
        // проверяем, если игрок ниже определённой высоты, то он упал

        while (true)
        {
            if(playerPosition.position.y <= -1
                && player.PlayerState != PlayerStates.Die)
            {
                player.GetDamage(150);
            }

            yield return new WaitForSeconds(.5f);
        }
    }
}
