using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyHandler : MonoBehaviour
{
    [SerializeField] private List<EnemyGroup> enemyGroups = new List<EnemyGroup>();

    private int aliveEnemyGroupsCount;
    public Action OnAllEnemyDead;

    public void GetEnemyGroups()
    {
        enemyGroups = GetComponentsInChildren<EnemyGroup>().ToList();

        for (int i = 0; i < enemyGroups.Count; i++)
        {
            aliveEnemyGroupsCount++;
            enemyGroups[i].OnEnemyGroupDied += OnEnemyGroupDied;
        }
    }

    private void OnEnemyGroupDied(EnemyGroup enemyGroup)
    {
        aliveEnemyGroupsCount--;

        if (aliveEnemyGroupsCount <= 0)
            OnAllEnemyDead?.Invoke();

        enemyGroup.OnEnemyGroupDied -= OnEnemyGroupDied;
    }
}
