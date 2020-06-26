using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostdefenderProjectile : Projectile
{
    protected override void OnTriggerEnter2D(Collider2D otherCollider)
    {
        var health = otherCollider.GetComponent<Health>();
        var attacker = otherCollider.GetComponent<Attacker>();
            
        if (health && attacker)
        {
            health.DealDamage(damage);
        }
        
    }
}
