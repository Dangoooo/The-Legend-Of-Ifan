using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOverTime : MonoBehaviour
{
    public float initialTime;
    private float currentTime;
    public GameObject thisGameobject;
    void Start()
    {
        currentTime = initialTime;
    }

    // Update is called once per frame
    void Update()
    {
        if(currentTime > 0)
        {
            currentTime -= Time.deltaTime;
        }
        else
        {
            Destroy(thisGameobject);
        }
    }
}
