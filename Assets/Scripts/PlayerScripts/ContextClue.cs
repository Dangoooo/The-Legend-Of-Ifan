using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContextClue : MonoBehaviour
{
    public GameObject contextClue;
    private bool contextClueActive;

   public void ChangeContextClue()
    {
        contextClueActive = !contextClueActive;
        if(contextClueActive)
        {
            contextClue.SetActive(true);
        }
        else
        {
            contextClue.SetActive(false);
        }
    }
}
