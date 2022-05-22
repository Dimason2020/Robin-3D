using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdollController : MonoBehaviour
{
    [Header("����������")]
    [SerializeField] private BoxCollider[] boxColliders;
    [SerializeField] private MeshCollider[] meshColliders;
    [SerializeField] private CapsuleCollider[] capsuleCollider;

    [Header("���������� ����")]
    [SerializeField] private Rigidbody[] rigidbodies;

    [Header("������ � �����")]
    [SerializeField] private Transform[] weapons;
    [SerializeField] private Transform[] armors;

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
        {
            rigidbodies[0].AddForce(transform.up * 150f, ForceMode.Impulse);
            ThrowWeapon();
            ThrowArmor();
        }
    }

    private void ThrowWeapon()
    {
        foreach (Transform item in weapons)
        {
            item.SetParent(null);
        }
    }

    public void ThrowArmor()
    {
        foreach (Transform item in armors)
        {
            item.SetParent(null);
            item.GetComponent<Rigidbody>().isKinematic = false;
            item.GetComponent<MeshCollider>().enabled = true;
        }
    }
}
