using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    [SerializeField] private Button _closeButton;

    private void Awake()
    {
        SetListeners();
    }

    private void SetListeners()
    {
        _closeButton.onClick.AddListener(() => gameObject.SetActive(false));
    }
}
