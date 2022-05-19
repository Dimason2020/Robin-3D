using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        Fly();
        StartCoroutine(DisableProjectile());
    }

    private void Fly()
    {
        rb.velocity = transform.forward * 15f;
    }

    private IEnumerator DisableProjectile()
    {
        yield return new WaitForSeconds(2f);

        gameObject.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.TryGetComponent(out Bot bot))
        {
            bot.GetDamage(25);
            gameObject.SetActive(false);
        }
    }
}
