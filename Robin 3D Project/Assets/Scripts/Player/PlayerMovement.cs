using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : Singleton<PlayerMovement>
{
    public PlayerStates PlayerState { get => currentState; }
    [SerializeField] private PlayerStates currentState;

    public RotationType RotationType { get => rotationType; }
    [SerializeField] private RotationType rotationType;

    private TouchInput touchInput;
    private Transform target;
    private Rigidbody rb;

    private Vector3 currentVelocity;

    public override void Awake()
    {
        base.Awake();

        rotationType = RotationType.NotFocused;

        touchInput = TouchInput.Instance;

        rb = GetComponent<Rigidbody>();
    }


    private void Update()
    {
        switch (currentState)
        {
            case PlayerStates.Idle:

                Idle();
                break;

            case PlayerStates.IdleAndAim:

                Idle();
                Rotate();
                break;

            case PlayerStates.Move:

                Move();
                Rotate();
                break;

            case PlayerStates.MoveAndAim:

                Move();
                Rotate();
                break;
        }
    }

    private void Idle()
    {
        if (touchInput.Stick.Horizontal != 0 && touchInput.Stick.Vertical != 0)
            currentState = PlayerStates.Move;
    }

    private void Move()
    {
        currentVelocity = new Vector3(touchInput.Stick.Horizontal, 0, touchInput.Stick.Vertical);

        rb.velocity = currentVelocity * 8;

        if (touchInput.Stick.Horizontal == 0 && touchInput.Stick.Vertical == 0)
            currentState = PlayerStates.Idle;
    }

    private void Rotate()
    {

        switch (rotationType)
        {
            case RotationType.Focused:

                Vector3 direction = target.position - transform.position;
                float rotate = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;

                transform.rotation = Quaternion.Euler(transform.rotation.x, 
                    rotate + 40f, transform.rotation.z);
                ChangeState(PlayerStates.MoveAndAim);
                break;

            case RotationType.NotFocused:

                float rotateY = Mathf.Atan2(touchInput.Stick.Horizontal, touchInput.Stick.Vertical)
                    * Mathf.Rad2Deg;

                if (touchInput.Stick.Horizontal != 0 || touchInput.Stick.Vertical != 0)
                {
                    transform.rotation = Quaternion.Euler(transform.rotation.x,
                        rotateY, transform.rotation.z);

                    ChangeState(PlayerStates.Move);

                }
                break;
        }
    }

    public void ChangeState(PlayerStates newState)
    {
        currentState = newState;
    }

    public void ChangeTargetForAim(Transform _target, RotationType _rotationType)
    {
        target = _target;
        rotationType = _rotationType;
    }
}