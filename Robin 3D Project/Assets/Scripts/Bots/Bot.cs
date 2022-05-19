using System;
using UnityEngine;

public class Bot : MonoBehaviour
{
    private RagdollController ragdollController;
    private CapsuleCollider capsuleCollider;
    private Animator animator;
    private Rigidbody rb;

    public bool Dead;
    public Action<Bot> OnBotDead;

    private void Awake()
    {
        ragdollController = GetComponentInChildren<RagdollController>();
        capsuleCollider = GetComponent<CapsuleCollider>();
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    public void Die()
    {
        capsuleCollider.enabled = false;
        animator.enabled = false;
        rb.AddForce(transform.up * 50f, ForceMode.Impulse);
        Dead = true;
        //Destroy(rb);
        //rb.isKinematic = true;

        ragdollController.SetRagdoll(true);

        OnBotDead?.Invoke(this);
    }
}
