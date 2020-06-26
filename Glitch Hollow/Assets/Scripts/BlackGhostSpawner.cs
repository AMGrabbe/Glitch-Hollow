using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackGhostSpawner : MonoBehaviour
{
    [Header("Timer Settings")]
    [SerializeField] float minSpawnDelay = 0f;
    [SerializeField] float maxSpawnDelay = 5f;


    [Header("Position Settings")]
    [SerializeField] int maxXPosition = 9;
    [SerializeField] int minXPosition = 6;
    [SerializeField] int maxYPosition = 5;
    [SerializeField] int minYPosition = 1;

    [Header("Prefab Settings")]
    [SerializeField] BlackGhost ghostPrefab;
   
    bool spawn = true;
    BlackGhost blackGhost;
    
    IEnumerator Start()
    {
        blackGhost = Instantiate(ghostPrefab, 
                                          transform.position, 
                                          transform.rotation) 
                                          as BlackGhost;
        blackGhost.transform.parent = transform;
        blackGhost.IsActive(false);
        while(spawn)
        {
            yield return new WaitForSeconds(Random.Range(minSpawnDelay, maxSpawnDelay));
            StartCoroutine(SpawnGhost(blackGhost));
        }
    }


    IEnumerator SpawnGhost(BlackGhost blackGhost)
    {
        blackGhost.transform.position = new Vector2(Random.Range(minXPosition,maxXPosition), 
                                      Random.Range(minYPosition,maxYPosition));
        blackGhost.IsActive(true);
        yield return new WaitForSeconds(2.0f);
        blackGhost.IsActive(false);
        //StartCoroutine(PlayAttackingAnimation(blackGhost));
    }
    public void StopActing()
    {
        spawn = false;
    }
}
