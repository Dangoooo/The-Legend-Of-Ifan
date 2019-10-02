using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ScreenKick()
    {
        anim.SetBool("kick", true);
        StartCoroutine(KickCo());
    }

    private IEnumerator KickCo()
    {
        yield return null;
        anim.SetBool("kick", false);
    }
}
