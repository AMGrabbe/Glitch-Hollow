using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puppet : MonoBehaviour
{
     private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        GameObject otherObject = otherCollider.gameObject;
        if(otherObject.GetComponent<Defender>())
        {
            if(otherObject.GetComponent<Rock>())
            {
                GetComponent<Animator>().SetTrigger("JumpTrigger");
            }
            else
            {
                GetComponent<Attacker>().Attack(otherObject);
            }
            
        }
    }
}
