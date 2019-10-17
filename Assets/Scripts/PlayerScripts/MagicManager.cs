using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MagicManager : MonoBehaviour
{
    public Slider magicSlider;
    public FloatValue playerMagic;
    void Start()
    {
        magicSlider.value = playerMagic.initialValue;
    }

    public void UpdateMagic()
    {
        magicSlider.value = playerMagic.initialValue;
        if(magicSlider.value > magicSlider.maxValue)
        {
            magicSlider.value = magicSlider.maxValue;
        }
        if (magicSlider.value < 0)
        {
            magicSlider.value = 0;
        }
    }
}
