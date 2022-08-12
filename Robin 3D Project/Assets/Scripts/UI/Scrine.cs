using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scrine : MonoBehaviour
{
    public GameObject winScrine;
    private void OnEnable()
    {
        SpearmanBoss.OnArmorDisable += OnWin;
    }

    private void OnDisable()
    {
        SpearmanBoss.OnArmorDisable -= OnWin;
    }

    private void OnWin()
    {
        winScrine.SetActive(true);
    }
}
