﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class FloatValue : ScriptableObject, ISerializationCallbackReceiver
{
    public float defaultValue;

    
    public float initialValue;
    public void OnBeforeSerialize()
    {
    }
    public void OnAfterDeserialize()
    {
        initialValue = defaultValue;
    }
}
