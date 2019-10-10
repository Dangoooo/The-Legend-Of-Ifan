using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public Signal contextClueSignal;
    public bool playerInRange;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && !collision.isTrigger)
        {
            if(contextClueSignal != null)
            {
                contextClueSignal.Raise();
                playerInRange = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && !collision.isTrigger)
        {
            if(contextClueSignal != null)
            {
                contextClueSignal.Raise();
                playerInRange = false;
            }
        }
    }
}
