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

    public void AddMagic()
    {
        magicSlider.value += 1;
        playerMagic.initialValue += 1;
        if(magicSlider.value > magicSlider.maxValue)
        {
            magicSlider.value = magicSlider.maxValue;
        }
    }

    public void DecreaseMagic()
    {
        magicSlider.value -= 1;
        playerMagic.initialValue -= 1;
        if (magicSlider.value < 0)
        {
            magicSlider.value = 0;
        }
    }
}
