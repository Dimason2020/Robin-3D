using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    [SerializeField] private Button _closeButton;
    [SerializeField] private GameObject _shopCanvas;
    [SerializeField] private GameObject _camera;

    private Player _player;

    private void Awake()
    {
        SetListeners();
    }

    public void ShowShopUI(Player player)
    {
        _player = player;
        _player.ChangeState(PlayerStates.EnterShop);
        _shopCanvas.SetActive(true);
        _camera.SetActive(true);
    }

    private void SetListeners()
    {
        _closeButton.onClick.AddListener(() => ExitShop());
    }

    private void ExitShop()
    {
        _player.ChangeState(PlayerStates.Idle);
        _shopCanvas.SetActive(false);
        _camera.SetActive(false);
    }
}
