using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyKillCounter : MonoBehaviour
{
    int enemyKillCounter = 0;

    public int GetKillCount()
    {
        return enemyKillCounter;
    }

    public void CountUpKillCounter()
    {
        enemyKillCounter++;
        
    }

    public void ResetKillCounter()
    {
        enemyKillCounter = 0;
    }
}
