using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonRoomTransfer : RoomTransfer
{
    public Door[] doors;

    public void Awake()
    {
        for (int i = 0; i < doors.Length; i++)
        {
            OpenAllDoor();
        }
    }

    public void CheckEnemy()
    {
        for (int i = 0; i < enemies.Length; i++)
        {
            if(enemies[i].gameObject.activeInHierarchy&&i<enemies.Length-1)
            {
                return;
            }
        }
        Debug.Log("jjdjdjk");
        OpenAllDoor();
    }

   public override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && !collision.isTrigger)
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

    public override void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && !collision.isTrigger)
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

    private void CloseAllDoor()
    {
        for (int i = 0; i < doors.Length; i++)
        {
            doors[i].CloseDoor();
        }
    }

    private void OpenAllDoor()
    {
        for (int i = 0; i < doors.Length; i++)
        {
            doors[i].OpenDoor();
        }
    }
}
