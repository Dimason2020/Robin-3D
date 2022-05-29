using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopCollider : MonoBehaviour
{
    public static event EventHandler<OnShopEnterEventArgs> OnShopEnter;
    public class OnShopEnterEventArgs : EventArgs
    {
        public Player playerObject;
    }
    //public static event EventHandler OnShopExit;

    private void OnTriggerEnter(Collider other)
    {
        var player = other.GetComponent<Player>();
        if (player != null)
        {
            OnShopEnter?.Invoke(this, new OnShopEnterEventArgs { playerObject = player });
        }
    }

   /* private void OnTriggerExit(Collider other)
    {
        var player = other.GetComponent<Player>();
        if (player != null)
        {
            OnShopExit?.Invoke(this, new EventArgs { });
        }
    }
   */
}
