using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System; 

public class DefenderSpawner : MonoBehaviour
{
    Defender defender;
    bool defenderIsSelected = false;
    GameObject defenderParent;
    const string DEFENDER_PARENT_NAME = "Defenders";

    int ghostDefenderCount = 0;
    bool ghostLimitation = false;

    [Tooltip("For Difficulties higher than 0 the maxGhost value is set to result of itself divided by the difficulty value.")]
    [SerializeField] float maxGhost = 4f;


    void Start(){
        CreateDefenderParent();
        SettingUpDifficulty();
    }

    private void SettingUpDifficulty()
    {
        float difficulty = PlayerPrefsController.GetDifficulty();
        if(difficulty > 0f)
        {
            ghostLimitation = true;
            maxGhost = maxGhost/difficulty;
        }
    }
    private void OnMouseDown()
    {
        Vector2 squarePosition = GetSquareClicked();
        if(defenderIsSelected)
        {
          AttemptToPlaceDefenderAt(squarePosition);  
        }
        
    }

    private void CreateDefenderParent()
    {
        defenderParent = GameObject.Find(DEFENDER_PARENT_NAME);
        if(!defenderParent)
        {
            defenderParent = new GameObject(DEFENDER_PARENT_NAME);
        }
    }

    private Vector2 GetSquareClicked()
    {
        Vector2 clickPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 worldPos = Camera.main.ScreenToWorldPoint(clickPos);
        Vector2 squarePosition = SnapToGrid(worldPos);
        return squarePosition;
    }

    private Vector2 SnapToGrid(Vector2 rawWorldPos)
    {
        float newXPos = Mathf.RoundToInt(rawWorldPos.x);
        float newYPos = Mathf.RoundToInt(rawWorldPos.y);
        return new Vector2(newXPos, newYPos);
    }

    private void SpawnDefender(Vector2 position)
    {
        Defender newDefender = Instantiate(defender, 
                                             position, 
                                             Quaternion.identity) as Defender;
        if (ghostLimitation == true  && defender.GetComponent<GhostDefender>())
            CountDefenderGhost();

        newDefender.transform.parent = defenderParent.transform;                                    
    }

    private void CountDefenderGhost()
    {
        ghostDefenderCount++;
        if(defender.GetComponent<GhostDefender>() && ghostDefenderCount >= maxGhost)
        {
           defenderIsSelected = false;
           FindObjectOfType<GhostButton>().Deactivate();
        }
    }


    public void SetSelectedDefender (Defender defenderToSelect)
    {
        defender = defenderToSelect;
        defenderIsSelected = true;
    }

    private void AttemptToPlaceDefenderAt( Vector2 squarePosition)
    {
        var CrystalDisplay = FindObjectOfType<CrystalsDisplay>();
        int defenderCost = defender.GetCost();


       
        if(CrystalDisplay.HaveEnoughCrystals(defenderCost))
        {
            SpawnDefender(squarePosition);
            CrystalDisplay.SpendCrystals(defenderCost);
        }

         
        
    }
}
