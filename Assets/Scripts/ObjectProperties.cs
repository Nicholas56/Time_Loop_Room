using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu]
public class ObjectProperties : ScriptableObject
{
    //A boolean to let the game know if the actions have been performed
    //bool hasDoneAction;
    //An array of events that the object will call out when interacted with
    public List<UnityEvent> events = new List<UnityEvent>();

    //This is the list of properties that any object can possess
    public enum property {Space, Line, Form, Light, Color, Texture, Pattern };

    //An array of properties, so that any object can have any number of properties
    public property[] type; 
    
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
}
