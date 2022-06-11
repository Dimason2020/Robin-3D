using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyGroup : MonoBehaviour
{
    [SerializeField] private List<BaseBotAI> enemys = new List<BaseBotAI>();

    private int enemyCount;
    public Action<EnemyGroup> OnEnemyGroupDied;

    private void Awake()
    {
        enemys = GetComponentsInChildren<BaseBotAI>().ToList();

        for (int i = 0; i < enemys.Count; i++)
        {
            enemyCount++;
            enemys[i].OnBotDead += OnBotDied;
        }
    }

    private void OnBotDied(BaseBotAI enemy)
    {
        enemyCount--;

        if (enemyCount <= 0)
            OnEnemyGroupDied?.Invoke(this);

        enemy.OnBotDead -= OnBotDied;
    }
}
