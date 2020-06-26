using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostDefender : MonoBehaviour
{
    [SerializeField] GameObject powerUpProjectile;
   Animator animator;
   EnemyKillCounter killCounter;


    void Start()
    {
        animator = GetComponent<Animator>();
        killCounter =FindObjectOfType<EnemyKillCounter>();
    }
   void Update()
   {
       if(killCounter.GetKillCount() >= 6)
       {
           StartCoroutine(SetPowerUp());
       }
   }

   IEnumerator SetPowerUp()
   {
       animator.SetBool("IsInPowerUp", true);
       GetComponent<Shooter>().SetProjectilePrefab(powerUpProjectile);
       yield return new WaitForSeconds(2f);
       killCounter.ResetKillCounter();
       animator.SetBool("IsInPowerUp", false);
   }
}
