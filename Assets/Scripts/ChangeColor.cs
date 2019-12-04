using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : ManipulateObject
{
    public Color[] colors;
    int colorNum;

    public void ColorCycle()
    {
        //The function gets the renderer from the object
        var renderer = GetComponent<Renderer>();
        //Then the color is changed to the current color from the array.
        renderer.material.SetColor("_Color", colors[colorNum]);

        //Every time the number is read, the value is increased and uses the length of the color array as a modulus.
        colorNum=(colorNum++) % colors.Length;
        //If the reverse bool is true and there's more than two colors, the color num just returns to the previous color.
        if (reverseAfterAction&&colorNum!=0&&colorNum!=1) { colorNum-=2; }
    }
}
