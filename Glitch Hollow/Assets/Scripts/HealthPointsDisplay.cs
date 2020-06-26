using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthPointsDisplay : MonoBehaviour
{
   [SerializeField] float baseHealth = 3;
   [SerializeField] int damage = 1;

   Text healthPointsText;
   float playerHealthPoints ;

   void Start()
    {
        playerHealthPoints = baseHealth - PlayerPrefsController.GetDifficulty();
        healthPointsText = GetComponent<Text>(); 
        UpdateDisplay();
    }

    private void UpdateDisplay()
    {
        healthPointsText.text = playerHealthPoints.ToString();
    }

    public void TakePlayerHealthPoints()
    {
        playerHealthPoints -= damage;
        UpdateDisplay();

        if (playerHealthPoints <= 0 )
        {
            FindObjectOfType<LevelController>().HandleLoseCondition();
        }
    }

}
