using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearmanGroup : MonoBehaviour
{
    [SerializeField] private Spearman spearmanPrefab;
    private SpearmanBoss spearmanBoss;

    private UnitSpawnPoint[] spawnPoints;

    private void Awake()
    {
        spawnPoints = GetComponentsInChildren<UnitSpawnPoint>();
    }

    private void Start()
    {
        spearmanBoss = SpearmanBoss.Instance;
        spearmanBoss.OnArmorEnded += ActivatedSpearmans;
    }

    private void OnDisable()
    {
        spearmanBoss.OnArmorEnded -= ActivatedSpearmans;
    }

    private void ActivatedSpearmans()
    {
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            Instantiate(spearmanPrefab, 
                spawnPoints[i].transform.position,
                spawnPoints[i].transform.rotation);
        }
    }
}
