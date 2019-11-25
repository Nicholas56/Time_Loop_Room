using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action : MonoBehaviour
{
    //The variable to affect the action
    public float actNum;

    //The type of actions that each oject will be able to perform
    public enum actionType { Position, Color, Rotation};
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
            case actionType.Position:
                break;
            case actionType.Color:
                break;
            case actionType.Rotation:
                break;
        }
    }
}
