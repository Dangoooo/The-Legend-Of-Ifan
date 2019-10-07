using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomTransfer : MonoBehaviour
{
    public GameObject virtualCamera;
    public GameObject text;
    public Text placeText;
    public string placeName;
    public Enemy[] enemies;
    public Pot[] pots;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual void  OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player"&&!collision.isTrigger)
        {
            virtualCamera.SetActive(true);
            StartCoroutine("PlaceNameCo");
            for (int i = 0; i < enemies.Length; i++)
            {
                ChangeActivation(enemies[i], true);
            }
            for (int i = 0; i < pots.Length; i++)
            {
                ChangeActivation(pots[i], true);
            }
        } 
    }

    public virtual void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player"&&!collision.isTrigger)
        {
            virtualCamera.SetActive(false);
            for (int i = 0; i < enemies.Length; i++)
            {
                ChangeActivation(enemies[i], false);
            }
            for (int i = 0; i < pots.Length; i++)
            {
                ChangeActivation(pots[i], false);
            }
        }
    }

    public       IEnumerator PlaceNameCo()
    {
        if(text != null)
        {
            text.SetActive(true);
            placeText.text = placeName;
            yield return new WaitForSeconds(4f);
            text.SetActive(false);
        }
    }
 
    public void ChangeActivation(Component component, bool isActive)
    {
        component.gameObject.SetActive(isActive);
    }
}
