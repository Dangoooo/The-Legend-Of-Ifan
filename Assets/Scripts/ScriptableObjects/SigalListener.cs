using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SigalListener : MonoBehaviour
{
    public Signal signal;
    public UnityEvent signalEvent;
    public void OnSignalRaised()
    {
        signalEvent.Invoke();
    }

    public void OnEnable()
    {
        signal.RegisterListener(this);
    }

    public void OnDisable()
    {
        signal.DeRegisterListener(this);
    }

}
