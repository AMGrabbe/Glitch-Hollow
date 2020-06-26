using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class BlackGhost : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        GameObject gameObject = otherCollider.gameObject;
        if(gameObject.GetComponent<Defender>())
        {
            GetComponent<Attacker>().Attack(gameObject);
        }
    }

    public void IsActive(bool status)
    {
            gameObject.SetActive(status); 
       
    }
   
}
