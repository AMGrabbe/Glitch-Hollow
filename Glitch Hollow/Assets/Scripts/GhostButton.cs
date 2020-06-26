using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GhostButton : MonoBehaviour
{
    GameObject soldOutTextObject;
    private void Start()
    {
        soldOutTextObject = gameObject.transform.Find("Sold Out").gameObject;
        soldOutTextObject.SetActive(false);
    }
    public void Deactivate()
    {
        //activate sold out text
        
        gameObject.GetComponent<Collider2D>().enabled = false;
        
        gameObject.GetComponentInChildren<Text>().enabled = false;
        soldOutTextObject.SetActive(true);

        gameObject.GetComponent<SpriteRenderer>().color = new Color32 (97,90,90,255);
    }
}
