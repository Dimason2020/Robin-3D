using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Singleton<Player>
{
    public PlayerStates PlayerState { get => currentState; }
    [SerializeField] private PlayerStates currentState;

    public RotationType RotationType { get => rotationType; }
    [SerializeField] private RotationType rotationType;

    public CharacterType Type { get => type;  }
    [SerializeField] private CharacterType type;

    [SerializeField] private MainCharacterData characterData;

    private TouchInput touchInput;
    private FocusArea focusArea;
    private Transform target;
    private Rigidbody rb;

    private Vector3 currentVelocity;

    public override void Awake()
    {
        base.Awake();

        rotationType = RotationType.NotFocused;

        touchInput = TouchInput.Instance;

        focusArea = GetComponentInChildren<FocusArea>();
        rb = GetComponent<Rigidbody>();
        ChangeState(PlayerStates.Idle);
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
                Attack();
                Rotate();
                break;

            case PlayerStates.Move:

                Move();
                Rotate();
                break;

            case PlayerStates.MoveAndAim:

                Move();
                Attack();
                Rotate();
                break;
        }
    }

    private void Idle()
    {
        if (touchInput.Stick.Horizontal != 0 && touchInput.Stick.Vertical != 0)
            currentState = PlayerStates.Move;
        else if (focusArea.IsHasTarget)
            currentState = PlayerStates.IdleAndAim;
        else if (!focusArea.IsHasTarget)
            currentState = PlayerStates.Idle;
    }

    private void Move()
    {
        currentVelocity = new Vector3(touchInput.Stick.Horizontal, 0, touchInput.Stick.Vertical);

        rb.velocity = currentVelocity.normalized * characterData.movementSpeed;

        if (touchInput.Stick.Horizontal == 0 && touchInput.Stick.Vertical == 0)
            currentState = PlayerStates.Idle;
        else if (focusArea.IsHasTarget)
            currentState = PlayerStates.MoveAndAim;
        else if (!focusArea.IsHasTarget)
            currentState = PlayerStates.Move;
    }

    private void Attack()
    {

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
                //ChangeState(PlayerStates.MoveAndAim);
                break;

            case RotationType.NotFocused:

                float rotateY = Mathf.Atan2(touchInput.Stick.Horizontal, touchInput.Stick.Vertical)
                    * Mathf.Rad2Deg;

                if (touchInput.Stick.Horizontal != 0 || touchInput.Stick.Vertical != 0)
                {
                    transform.rotation = Quaternion.Euler(transform.rotation.x,
                        rotateY, transform.rotation.z);

                    //ChangeState(PlayerStates.Move);

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
