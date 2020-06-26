using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phantom : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        GameObject gameObject = otherCollider.gameObject;
        if(gameObject.GetComponent<Defender>())
        {
            GetComponent<Attacker>().Attack(gameObject);
        }
    }
}
