using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackGhostProjectile : Projectile
{
    protected override void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }

    protected override void OnTriggerEnter2D(Collider2D otherCollider)
    {
        var health = otherCollider.GetComponent<Health>();
        var defender = otherCollider.GetComponent<Defender>();

        if( health && defender)
        { 
            health.DealDamage(damage);
        }
    }
}
