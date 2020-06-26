using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Health : MonoBehaviour
{
    [SerializeField] float health = 100f;
    [SerializeField] GameObject deathVFX;

    HealthBar healthBar;

    void Start()
    {
        healthBar = GetComponentInChildren<HealthBar>();
        healthBar.SetUpHealthBar(health);
    }
    public void DealDamage(float damage)
    {
        health -= damage;
        healthBar.SetHealthBarValue(health);
        if(health <= 0)
        {
            TriggerDeathVFX(); 
            Destroy(gameObject);
            if(GetComponent<Attacker>())
            {
               FindObjectOfType<EnemyKillCounter>().CountUpKillCounter();
            }
        }
            
    }

    private void TriggerDeathVFX()
    {
        if(!deathVFX)
        {
            return;
        }
        GameObject deathVFXObject = Instantiate(deathVFX, transform.position, Quaternion.identity);
        Destroy(deathVFXObject, 1f);
    }
}
