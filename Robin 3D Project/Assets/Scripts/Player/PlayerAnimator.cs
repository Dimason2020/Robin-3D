using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private PlayerMovement playerMovement;
    private TouchInput touchInput;
    private Animator animator;

    private void Awake()
    {
        touchInput = TouchInput.Instance;

        playerMovement = GetComponent<PlayerMovement>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        CheckCurrentState();
    }

    private void CheckCurrentState()
    {
        switch (playerMovement.PlayerState)
        {
            case PlayerStates.Idle:

                SetAnimation("idle");
                break;

            case PlayerStates.IdleAndAim:

                SetAnimation("idle");
                break;

            case PlayerStates.Move:

                SetAnimation("move");
                break;

            case PlayerStates.MoveAndAim:

                SetAnimation("focusedMove");
                break;
        }
    }

    private void SetAnimation(string newAnim)
    {
        animator.SetBool("idle", false);
        animator.SetBool("move", false);
        animator.SetBool("focusedMove", false);

        animator.SetBool(newAnim, true);
        SetAnimationVelocity();
    }

    private void SetAnimationVelocity()
    {
        Vector3 movement = new Vector3(touchInput.Stick.Horizontal, 0, touchInput.Stick.Vertical);

        float velocityZ = Vector3.Dot(movement.normalized, transform.forward);
        float velocityX = Vector3.Dot(movement.normalized, transform.right);

        animator.SetFloat("VelocityX", velocityX, 0.1f, Time.deltaTime);
        animator.SetFloat("VelocityZ", velocityZ, 0.1f, Time.deltaTime);
    }
}
