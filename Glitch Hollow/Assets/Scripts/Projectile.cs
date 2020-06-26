using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] protected float speed = 1f;
    [SerializeField] protected float damage = 100;
   

    protected virtual void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    protected virtual void OnTriggerEnter2D(Collider2D otherCollider)
    {
        //reduce health of otherCollider
        var health = otherCollider.GetComponent<Health>();
        var attacker = otherCollider.GetComponent<Attacker>();

        if( health && attacker)
        {
            health.DealDamage(damage);
            Destroy(gameObject);
        }
    }
}
