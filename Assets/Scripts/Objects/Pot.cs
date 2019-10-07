using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pot : MonoBehaviour
{
    private Animator anim;
    public LootTable lootTable;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Destroy()
    {
        anim.SetBool("destroy", true);
        StartCoroutine(DestroyCo());
    }

    IEnumerator DestroyCo()
    {
        yield return new WaitForSeconds(0.3f);
        this.gameObject.SetActive(false);
        CreateLoot();
    }

    private void CreateLoot()
    {
        if (lootTable != null)
        {
            PowerUp power = lootTable.CreateLoot();
            if (power != null)
            {
                Instantiate(power.gameObject, transform.position, Quaternion.identity);
            }
        }
    }
}
