using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{

    [SerializeField] GameObject winLabel;
    [SerializeField] GameObject loseLabel;

    [SerializeField] bool isLastLevel = false;
    [SerializeField] float waitingTimeBeforeLabel = 4f;
    int attackerCount = 0;
    bool levelTimerFinished = false;

    
    public void Start()
    {
        winLabel.SetActive(false);
        loseLabel.SetActive(false);
    }

    public void AttackerSpawned()
    {
        attackerCount++;
    }

    public void AttackerDestroyed()
    {
        attackerCount--;
        if (attackerCount == 0 && levelTimerFinished)
        {
            StartCoroutine(HandleWinCondition());
        }
    }

    public void LevelTimerFinished()
    {
        levelTimerFinished = true;
        StopSpawners();
    }

    private void StopSpawners()
    {
        AttackerSpawner[] spawnerArray = FindObjectsOfType<AttackerSpawner>();
        BlackGhostSpawner blackGhost = FindObjectOfType<BlackGhostSpawner>();

        foreach(AttackerSpawner spawner in spawnerArray)
        {
            spawner.StopSpawning();
        }
        
        if(blackGhost)
        {
            blackGhost.StopActing();
        }
        
    }

    IEnumerator HandleWinCondition()
    {
        if(isLastLevel)
        {
            winLabel.SetActive(true);
            yield return new WaitForSeconds(waitingTimeBeforeLabel);
        }
        else
        {
            winLabel.SetActive(true);
            yield return new WaitForSeconds(waitingTimeBeforeLabel);
            FindObjectOfType<LevelLoader>().LoadNextScene();
        }
       
    }

    public void HandleLoseCondition()
    {
        loseLabel.SetActive(true);
        //stopping gameflow with timescale = 0;
        Time.timeScale = 0;
    }
}
