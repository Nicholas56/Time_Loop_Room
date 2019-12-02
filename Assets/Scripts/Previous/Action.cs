using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Action : ScriptableObject
{ 
    //The variable to affect the action
    public float actNum;

    //The type of actions that each oject will be able to perform
    public enum actionType { XPosition, YPosition, Color, Rotation};
    public actionType action;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void PerformAction()
    {
        //When the perform action method is called, the switch case will determine which action to perform
        switch (action)
        {
            case actionType.XPosition:
                
                break;
            case actionType.YPosition:

                break;
            case actionType.Color:
                break;
            case actionType.Rotation:
                break;
        }
    }
}
