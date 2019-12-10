using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ObjectProperties
{
    //A boolean to let the game know if the actions have been performed
    //bool hasDoneAction;
    //An array of events that the object will call out when interacted with
    public List<UnityEvent> events = new List<UnityEvent>();

    //This is the list of properties that any object can possess
    public enum property {Space, Line, Form, Light, Color, Texture, Pattern };

    //An array of properties, so that any object can have any number of properties
    public property[] type; 

    public ObjectProperties(List<UnityEvent> newList, property[] newType)
    {
        events = newList;
        type = newType;
    }

    public ObjectProperties(property[] newType)
    {
        type = newType;
    }
    
    //When Action() is called, every action assigned to object is performed
    public void Action()
    {
        //Checks that the actions haven't already been performed
       // if (!hasDoneAction)
        {
            //Runs though each action and performs them in that order
            foreach (UnityEvent action in events)
            {
                action.Invoke();
            }
            //Sets the boolean to true so that the object cannot perform any more actions
            //hasDoneAction = true;
        }
    }

    public property AddRandomType()
    {
        int randNum = Random.Range(0, 7);
        switch (randNum)
        {
            case 0:
                return property.Space;
                break;
            case 1:
                return property.Line;
                break;
            case 2:
                return property.Form;
                break;
            case 3:
                return property.Light;
                break;
            case 4:
                return property.Color;
                break;
            case 5:
                return property.Texture;
                break;
            case 6:
                return property.Pattern;
                break;
            default:
                return property.Space;
                break;
        }
    }
}
