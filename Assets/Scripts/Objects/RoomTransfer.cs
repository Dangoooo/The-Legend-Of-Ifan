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
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            virtualCamera.SetActive(true);
            StartCoroutine("PlaceNameCo");
        } 
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            virtualCamera.SetActive(false);
        }
    }

    private IEnumerator PlaceNameCo()
    {
        if(text != null)
        {
            text.SetActive(true);
            placeText.text = placeName;
            yield return new WaitForSeconds(4f);
            text.SetActive(false);
        }
    }
 
    
}
