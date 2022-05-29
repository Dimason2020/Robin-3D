using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomChecker : MonoBehaviour
{
    [SerializeField] private Direction direction;

    public bool IsBusy { get => isBusy; }
    [SerializeField] private bool isBusy;

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out AnchorPoint anchorPoint))
        {
            isBusy = true;
        }
    }
}
