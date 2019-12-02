using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameEventListener : MonoBehaviour
{
    public GameEvent[] Event;
    public UnityEvent Response;

    private void OnEnable()
    {
        for (int i = 0; i < Event.Length; i++)
        {
            Event[i].RegisterListener(this);
        }
    }

    private void OnDisable()
    {
        for (int i = 0; i < Event.Length; i++)
        {
            Event[i].UnRegisterListener(this);
        }
    }

    public void OnEventRaised()
    {
        Response.Invoke();
    }
}
