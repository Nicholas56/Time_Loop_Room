using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectProperties : MonoBehaviour
{
    //A boolean to let the game know if the actions have been performed
    bool hasDoneAction;
    //An array of actions that the object will carry out when interacted with
    public Action[] actions;

    //This is the list of properties that any object can possess
    public enum property {Space, Line, Form, Light, Color, Texture, Pattern };
    //An array of properties, so that any object can have any number of properties
    public property[] type; 
    
    //When Action() is called, every action assigned to object is performed
    void Action()
    {
        //Checks that the actions haven't already been performed
        if (!hasDoneAction)
        {
            //Runs though each action and performs them in that order
            foreach (Action action in actions)
            {
                action.PerformAction();
            }
            //Sets the boolean to true so that the object cannot perform any more actions
            hasDoneAction = true;
        }
    }
}
