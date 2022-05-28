using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private Player player;
    private TouchInput touchInput;
    private Animator animator;

    private void Awake()
    {
        touchInput = TouchInput.Instance;

        player = GetComponent<Player>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        CheckCurrentState();
    }

    private void CheckCurrentState()
    {
        switch (player.PlayerState)
        {
            case PlayerStates.Idle:

                animator.SetBool("focusedMove", false);
                SetAnimation("idle");
                break;

            case PlayerStates.IdleAndAim:

                animator.SetBool("focusedMove", true);
                break;

            case PlayerStates.Move:

                animator.SetBool("focusedMove", false);
                SetAnimation("move");
                break;

            case PlayerStates.MoveAndAim:

                animator.SetBool("focusedMove", true);
                break;

            case PlayerStates.EnterShop:

                animator.SetBool("focusedMove", false);
                SetAnimation("idle");
                break;

            case PlayerStates.Die:

                animator.SetBool("focusedMove", false);
                SetAnimation("die");
                break;
        }
    }

    private void SetAnimation(string newAnim)
    {
        animator.SetBool("idle", false);
        animator.SetBool("move", false);
        animator.SetBool("die", false);

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
