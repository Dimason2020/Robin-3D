using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateHandler : MonoBehaviour
{
    public PlayerStates PlayerState { get => currentState; }
    [SerializeField] private PlayerStates currentState;

    public RotationType RotationType { get => rotationType; }
    [SerializeField] private RotationType rotationType;

    private void Update()
    {
        switch (currentState)
        {
            case PlayerStates.Idle:

                break;

            case PlayerStates.IdleAndAim:

                break;

            case PlayerStates.Move:

                break;

            case PlayerStates.MoveAndAim:

                break;
        }
    }
}
