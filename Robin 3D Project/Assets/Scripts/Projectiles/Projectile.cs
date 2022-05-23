using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Rigidbody rb;
    private CharacterType targetType;

    private int damagePoint;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        
    }

    private void Fly()
    {
        rb.velocity = transform.forward * 15f;
    }

    public void SetProjectile(CharacterType _targetType, int _damagePoint)
    {
        damagePoint = _damagePoint;
        targetType = _targetType;
        Fly();
        StartCoroutine(DisableProjectile());
    }

    private IEnumerator DisableProjectile()
    {
        yield return new WaitForSeconds(2f);

        gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider collider)
    {
        if(collider.TryGetComponent(out BaseBotAI bot)
            && targetType == bot.Type)
        {
            bot.GetDamage(damagePoint);
            gameObject.SetActive(false);
        }

        if (collider.TryGetComponent(out Player player)
            && targetType == player.Type)
        {
            player.GetDamage(damagePoint);
            gameObject.SetActive(false);
        }
    }
}
