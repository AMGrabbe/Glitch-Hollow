using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageCollider : MonoBehaviour
{
   private void OnTriggerEnter2D (Collider2D otherCollider)
   {
       if(!otherCollider.GetComponent<BlackGhostProjectile>() || !otherCollider.GetComponent<GhostdefenderProjectile>())
       {
           FindObjectOfType<HealthPointsDisplay>().TakePlayerHealthPoints();
       }
       Destroy(otherCollider.gameObject);
   }
}
