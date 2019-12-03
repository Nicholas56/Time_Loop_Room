using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManipulateObject : MonoBehaviour
{
    //This script will be used to manipulate every object in relation to the elemental properties of the game

    public float manipulationValue;
    public bool reverseAfterAction;
    public enum direction { Up, Down, Left, Right, Grow, Shrink, Open, Close, Light, Dark}
    public direction command;
    public void Reposition()
    {
        switch (command)
        {
            case direction.Up:
                transform.position += new Vector3(0, manipulationValue, 0);
                if (reverseAfterAction) { command = direction.Down; }
                break;
            case direction.Down:
                transform.position += new Vector3(0, -manipulationValue, 0);
                if (reverseAfterAction) { command = direction.Up; }
                break;


            case direction.Left:
                transform.Rotate(-90f, 0f, 0f);
                if (reverseAfterAction) { command = direction.Right; }
                break;
            case direction.Right:
                transform.Rotate(90f, 0f, 0f);
                if (reverseAfterAction) { command = direction.Left; }
                break;


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


            case direction.Open:
                reverseAfterAction = true;
                if (reverseAfterAction) { command = direction.Close; }
                break;
            case direction.Close:
                reverseAfterAction = true;
                if (reverseAfterAction) { command = direction.Open; }
                break;


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
