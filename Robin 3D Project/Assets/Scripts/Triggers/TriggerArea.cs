using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerArea : MonoBehaviour
{
    private BaseBotData botData;
    private BaseBotAI botAI;

    private SphereCollider triggerCollider;

    public Transform Target { get => target; }
    public bool PlayerInRange { get => playerInRange; }
    public float Distance
    {
        get
        {
            float distance = Vector3.Distance(transform.position, target.position);
            return distance;
        }
    }

    private bool playerInRange;
    private Transform target;

    private void Start()
    {
        botAI = GetComponentInParent<BaseBotAI>();
        botData = botAI.botData;

        triggerCollider.radius = botData.triggerDistance;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out PlayerMovement player))
        {
            target = player.transform;
            playerInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out PlayerMovement player))
        {
            playerInRange = false;
        }
    }
}
