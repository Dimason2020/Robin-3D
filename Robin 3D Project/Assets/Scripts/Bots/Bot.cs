using System;
using UnityEngine;

public class Bot : BaseMeleeBot
{
    private RagdollController ragdollController;
    private CapsuleCollider capsuleCollider;
    private Rigidbody rb;

    public bool Dead;
    public Action<Bot> OnBotDead;

    protected override void Awake()
    {
        base.Awake();

        ragdollController = GetComponentInChildren<RagdollController>();
        capsuleCollider = GetComponent<CapsuleCollider>();
        rb = GetComponent<Rigidbody>();
    }

    protected override void Die()
    {
        base.Die();

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
