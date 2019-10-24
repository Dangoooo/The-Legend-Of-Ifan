using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ReSignal : ScriptableObject
{
    public List<SigalListener> listeners = new List<SigalListener>();

    public void Raise()
    {
        for(int i=listeners.Count-1; i>=0; i--)
        {
            listeners[i].OnSignalRaised();
        }
    }

    public void RegisterListener(SigalListener listener)
    {
        listeners.Add(listener);
    }

    public void DeRegisterListener(SigalListener listener)
    {
        listeners.Remove(listener); 
    }
   
}
