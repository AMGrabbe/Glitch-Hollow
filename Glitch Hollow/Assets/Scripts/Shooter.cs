using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] protected GameObject projectile, projectileCreator;
    AttackerSpawner myLaneSpawner;
    Animator animator;
    GameObject projectileParent;
    const string PROJECTILE_PARENT_NAME = "Projectile";

    protected virtual void Start()
    {
        SetLaneSpawner();
        animator = GetComponent<Animator>();
        CreateProjectileParent();
    }
    
    protected void CreateProjectileParent()
    {
        projectileParent = GameObject.Find(PROJECTILE_PARENT_NAME);
        if(!projectileParent)
        {
            projectileParent = new GameObject(PROJECTILE_PARENT_NAME);
        }
    }
    protected virtual void Update()
    {
        if (IsAttackerInLane())   
        {
            animator.SetBool("IsAttacking", true);
        }
        else 
        {
            animator.SetBool("IsAttacking", false);
        }
    }

    private bool IsAttackerInLane()
    {
        if ( myLaneSpawner.transform.childCount <= 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    protected void Attack()
    {
        GameObject newProjectile = Instantiate(projectile, 
                                   projectileCreator.transform.position, 
                                   Quaternion.identity) as GameObject;
        newProjectile.transform.parent = projectileParent.transform;
    }
    
    private void SetLaneSpawner()
    {
        AttackerSpawner[] allSpawners = FindObjectsOfType<AttackerSpawner>();

        foreach ( AttackerSpawner spawner in allSpawners)
        {
            bool IsCloseEnough = (Mathf.Abs(spawner.transform.position.y
                                            - transform.position.y) 
                                  <= Mathf.Epsilon);
            if (IsCloseEnough)
            {
                myLaneSpawner = spawner;
            }
        }
    }

    public void SetProjectilePrefab(GameObject prefab)
    {
        projectile = prefab;
    }
   
}
