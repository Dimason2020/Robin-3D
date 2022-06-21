using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bow : MonoBehaviour
{
    [SerializeField] private Weapons _weaponType;
    [Space]
    [Header("Buttons")]
    [SerializeField] private Button _buyButton;
    [SerializeField] private Button _equipButton;
    [SerializeField] private Button _upgradeButton;
    [Space]
    [Header("Upgrade")]
    [SerializeField] private List<Image> _upgradeIcon;
    [Space]
    [Header("Essentials")]
    [SerializeField] private Mesh _mesh;
    [SerializeField] private int _attack = 20;

    private int _upgradeAmount;

    public static event EventHandler<OnEquipEventArgs> OnEquip;

    public class OnEquipEventArgs : EventArgs 
    {
        public Mesh mesh;
        public int attack;
    }

    private void Awake()
    {
        CheckIfSimple();
        SetListeners();
    }

    private void SetListeners()
    {
        _buyButton.onClick.AddListener(() => Buy());
        _upgradeButton.onClick.AddListener(() => Upgrade());
        _equipButton.onClick.AddListener(() => Equip());
    }

    private void CheckIfSimple()
    {
        if (_weaponType == Weapons.Simple)
        {
            Buy();
            Equip();
        }
    }

    private void Buy()
    {
        _buyButton.gameObject.SetActive(false);
        _equipButton.gameObject.SetActive(true);
        _upgradeButton.gameObject.SetActive(true);
    }

    private void Upgrade()
    {
        if (_upgradeAmount < _upgradeIcon.Capacity)
        {
            _upgradeIcon[_upgradeAmount].color = Color.blue;
            _upgradeAmount++;
            if(_upgradeAmount == _upgradeIcon.Capacity) _upgradeButton.interactable = false;
        }
    }

    private void Equip()
    {
        OnEquip?.Invoke(this, new OnEquipEventArgs { mesh = _mesh, attack = _attack });
    }
}
