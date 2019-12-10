using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManipulateObject : MonoBehaviour
{
    //This script will be used to manipulate every object in relation to the elemental properties of the game

    public float manipulationValue; //This is the value used to manipulate the object in various ways
    public bool reverseAfterAction; //This boolean allows the action to reverse to previous state
    public enum direction { Up, Down, Left, Right, Grow, Shrink, Open, Close, Light, Dark}
    public direction command;

    //This function is called through events
    public void Reposition()
    {
        Debug.Log("Manipulation has occurred");
        switch (command)
        {
            //These two cases move the object up and down
            case direction.Up:
                transform.position += new Vector3(0, manipulationValue, 0);
                if (reverseAfterAction) { command = direction.Down; }
                break;
            case direction.Down:
                transform.position += new Vector3(0, -manipulationValue, 0);
                if (reverseAfterAction) { command = direction.Up; }
                break;

            //These two cases rotate the object left and right
            case direction.Left:
                transform.Rotate(-90f, 0f, 0f);
                if (reverseAfterAction) { command = direction.Right; }
                break;
            case direction.Right:
                transform.Rotate(90f, 0f, 0f);
                if (reverseAfterAction) { command = direction.Left; }
                break;

            //These two cases double and half the size of the object
            case direction.Grow:
                reverseAfterAction = true;
                transform.localScale *= 2;
                if (reverseAfterAction) { command = direction.Shrink; }
                break;
            case direction.Shrink:
                reverseAfterAction = true;
                transform.localScale /= 2;
                if (reverseAfterAction) { command = direction.Grow; }
                break;

            //These two cases open and close the object
            case direction.Open:
                reverseAfterAction = true;
                if (reverseAfterAction) { command = direction.Close; }
                break;
            case direction.Close:
                reverseAfterAction = true;
                if (reverseAfterAction) { command = direction.Open; }
                break;

            //These two cases change the intensity of the light on the object
            case direction.Light:
                gameObject.GetComponent<Light>().intensity += manipulationValue;
                if (reverseAfterAction) { command = direction.Dark; }
                break;
            case direction.Dark:
                gameObject.GetComponent<Light>().intensity -= manipulationValue;
                if (reverseAfterAction) { command = direction.Light; }
                break;
        }
    }
}
