using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Properties
{
    //This script will keep track of the internal scores within the game as defined by the properties

    //Array of property scores
    //0 = Space, 1 = Line, 2 = Form, 3 = Light, 4 = Color, 5 = Texture, 6 = Pattern
    private static int[] properties = new int[7];


    //External scripts can read values, but cannot change them
    public static int Space { get { return properties[0]; } }
    public static int Line { get { return properties[1]; } }
    public static int Form { get { return properties[2]; } }
    public static int Light { get { return properties[3]; } }
    public static int Color { get { return properties[4]; } }
    public static int Texture { get { return properties[5]; } }
    public static int Pattern { get { return properties[6]; } }

    public static void Increase(string propertyToIncrease, int amount)
    {
        switch (propertyToIncrease)
        {
            case "Space":
                properties[0] += amount;
                break;
            case "Line":
                properties[1] += amount;
                break;
            case "Form":
                properties[2] += amount;
                break;
            case "Light":
                properties[3] += amount;
                break;
            case "Color":
                properties[4] += amount;
                break;
            case "Texture":
                properties[5] += amount;
                break;
            case "Pattern":
                properties[6] += amount;
                break;

        }
    }

    public static void Decrease(string propertyToDecrease, int amount)
    {
        switch (propertyToDecrease)
        {
            case "Space":
                properties[0] -= amount;
                break;
            case "Line":
                properties[1] -= amount;
                break;
            case "Form":
                properties[2] -= amount;
                break;
            case "Light":
                properties[3] -= amount;
                break;
            case "Color":
                properties[4] -= amount;
                break;
            case "Texture":
                properties[5] -= amount;
                break;
            case "Pattern":
                properties[6] -= amount;
                break;

        }
    }
}
