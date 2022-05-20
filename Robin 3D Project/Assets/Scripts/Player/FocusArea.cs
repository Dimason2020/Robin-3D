using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FocusArea : MonoBehaviour
{
    private Player player;

    [SerializeField] private Transform area;
    [SerializeField] private Transform targetCircle;

    public bool IsHasTarget { get => targets.Count != 0; }
    [SerializeField] private List<Bot> targets = new List<Bot>();

    private void Awake()
    {
        player = GetComponentInParent<Player>();

        area.SetParent(null);
        targetCircle.SetParent(null);
        targetCircle.gameObject.SetActive(false);
    }

    private void Update()
    {
        area.position = new Vector3(transform.position.x,
            area.position.y,
            transform.position.z);

        if(targets.Count >= 1)
        {
            Transform targetPos = GetClosestEnemy(targets);

            player.ChangeTargetForAim(targetPos,
                RotationType.Focused);

            targetCircle.position = new Vector3(targetPos.position.x,
                targetCircle.position.y,
                targetPos.position.z);
            targetCircle.gameObject.SetActive(true);

        }
    }

    private void RemoveBotFromList(Bot bot)
    {
        bot.OnBotDead -= RemoveBotFromList;
        targets.Remove(bot);

        if(targets.Count <= 0)
        {
            player.ChangeTargetForAim(null, RotationType.NotFocused);
            targetCircle.gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out Bot bot)
            && !bot.Dead)
        {
            targets.Add(bot);
            bot.OnBotDead += RemoveBotFromList;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out Bot bot))
        {
            RemoveBotFromList(bot);
        }
    }

    private Transform GetClosestEnemy(List<Bot> enemies)
    {
        Transform closestEnemy = null;
        float minDist = Mathf.Infinity;
        Vector3 currentPos = transform.position;
        foreach (Bot enemy in enemies)
        {
            float dist = Vector3.Distance(enemy.transform.position, currentPos);
            if (dist < minDist)
            {
                closestEnemy = enemy.transform;
                minDist = dist;
            }
        }
        return closestEnemy;
    }
}
