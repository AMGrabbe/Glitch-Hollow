using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defender : MonoBehaviour
{
   [SerializeField] int cost = 10;

   public void AddCrystals(int amount)
   {
      FindObjectOfType<CrystalsDisplay>().AddCrystals(amount);
   }

   public int GetCost()
   {
      return cost;
   }
}
