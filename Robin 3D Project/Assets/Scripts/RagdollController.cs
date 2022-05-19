using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdollController : MonoBehaviour
{
    [Header("Коллайдеры")]
    [SerializeField] private BoxCollider[] boxColliders;
    [SerializeField] private MeshCollider[] meshColliders;
    [SerializeField] private CapsuleCollider[] capsuleCollider;

    [Header("Физические тела")]
    [SerializeField] private Rigidbody[] rigidbodies;

    [Header("Оружие в руках")]
    [SerializeField] private Transform[] weapons;

    private void Awake()
    {
        GetComponentsToArray();

        SetRagdoll(false);
    }

    private void GetComponentsToArray()
    {
        boxColliders = GetComponentsInChildren<BoxCollider>();
        meshColliders = GetComponentsInChildren<MeshCollider>();
        capsuleCollider = GetComponentsInChildren<CapsuleCollider>();

        rigidbodies = GetComponentsInChildren<Rigidbody>();
    }

    public void SetRagdoll(bool flag)
    {
        foreach (BoxCollider item in boxColliders)
        {
            item.enabled = flag;
        }

        foreach (CapsuleCollider item in capsuleCollider)
        {
            item.enabled = flag;
        }

        foreach (MeshCollider item in meshColliders)
        {
            item.enabled = flag;
        }

        foreach (Rigidbody item in rigidbodies)
        {
            item.isKinematic = !flag;
        }

        if (flag)
            ThrowWeapon();
    }

    private void ThrowWeapon()
    {
        foreach (Transform item in weapons)
        {
            item.SetParent(null);
        }
    }
}
