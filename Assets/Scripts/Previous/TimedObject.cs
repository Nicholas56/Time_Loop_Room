using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedObject : ObjectProperties
{
    public float timeOfAction;

    private void Start()
    {
        //Invoke("Action", timeOfAction);
    }

    public void Action()
    {

    }
}
