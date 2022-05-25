using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeapon : MonoBehaviour
{
    private BaseBotAI botAI;
    private BaseBotData botData;
    private MeshCollider meshCollider;

    private void Awake()
    {
        meshCollider = GetComponent<MeshCollider>();

        botAI = GetComponentInParent<BaseBotAI>();
        botData = botAI.botData;
    }

    public void EnableCollider()
    {
        meshCollider.enabled = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out Player player))
        {
            player.GetDamage(botData.attackPoint);
            meshCollider.enabled = false;
        }
    }
}
