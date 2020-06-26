using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CrystalsDisplay : MonoBehaviour
{
    [SerializeField] int crystals = 100;
    Text crystalsText;

    void Start()
    {
        crystalsText = GetComponent<Text>(); 
        UpdateDisplay();
    }

    private void UpdateDisplay()
    {
        crystalsText.text = crystals.ToString();
    }

    public void AddCrystals(int amount)
    {
        crystals += amount;
        UpdateDisplay();
    }

    public void SpendCrystals(int cost)
    {
        if ( crystals >= cost)
        {
            crystals -= cost;
            UpdateDisplay();  
        }
    }

    public bool HaveEnoughCrystals( int cost )
    {
        return (cost <= crystals);
    }
}
