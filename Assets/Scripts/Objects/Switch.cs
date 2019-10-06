using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    public BoolValue isDown;
    public Door thisDoor;
    public Sprite switchDown;
    private SpriteRenderer mySpriteRenderer;
    void Start()
    {
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        if(isDown.initialValue)
        {
            mySpriteRenderer.sprite = switchDown;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player" && !isDown.initialValue)
        {
            SwitchDown();
        }
    }

    private void SwitchDown()
    {
        isDown.initialValue = true;
        mySpriteRenderer.sprite = switchDown;
        thisDoor.OpenDoor();
    }
}
