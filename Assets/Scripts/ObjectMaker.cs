using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMaker : MonoBehaviour
{
    public ObjectProperties givenProperty;

    public GameObject segmentObject;

    // Start is called before the first frame update
    void Start()
    {
        GameObject madeObject = Instantiate(segmentObject, transform.position+new Vector3(0,1,0), Quaternion.identity);
        madeObject.AddComponent<ObjectInGame>();
        madeObject.GetComponent<ObjectInGame>().properties = givenProperty;
        madeObject.transform.SetParent(transform);

        //As the object is created and given properties, certain components need to be added to it so it functions correctly
        //The Object Information NEEDS TO COME FROM DATA!!
        for (int i = 0; i < madeObject.GetComponent<ObjectInGame>().properties.type.Length; i++) {
            switch (madeObject.GetComponent<ObjectInGame>().properties.type[i])
            {
                case ObjectProperties.property.Space:
                    madeObject.AddComponent<ManipulateObject>();
                    madeObject.GetComponent<ManipulateObject>().command = ManipulateObject.direction.Down;
                    madeObject.GetComponent<ManipulateObject>().manipulationValue = 2;
                    break;
                case ObjectProperties.property.Line:
                    madeObject.AddComponent<ManipulateObject>();
                    madeObject.GetComponent<ManipulateObject>().command = ManipulateObject.direction.Right;
                    break;
                case ObjectProperties.property.Form:
                    madeObject.AddComponent<ManipulateObject>();
                    madeObject.GetComponent<ManipulateObject>().command = ManipulateObject.direction.Grow;
                    break;
                case ObjectProperties.property.Light:
                    madeObject.AddComponent<Light>();
                    madeObject.GetComponent<Light>().color = Color.red;
                    madeObject.AddComponent<ManipulateObject>();
                    madeObject.GetComponent<ManipulateObject>().command = ManipulateObject.direction.Light;
                    madeObject.GetComponent<ManipulateObject>().manipulationValue = 50;
                    break;
                case ObjectProperties.property.Color:
                    madeObject.AddComponent<ChangeColor>();
                    break;
                case ObjectProperties.property.Texture:

                    break;
                case ObjectProperties.property.Pattern:

                    break;
                default:
                    break;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
