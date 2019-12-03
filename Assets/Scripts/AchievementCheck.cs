using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievementCheck : MonoBehaviour
{
    GameObject[] objects;
    List<GameObject> spaceObjects = new List<GameObject>();
    List<GameObject> lineObjects = new List<GameObject>();
    List<GameObject> formObjects = new List<GameObject>();
    List<GameObject> lightObjects = new List<GameObject>();
    List<GameObject> colorObjects = new List<GameObject>();
    List<GameObject> textureObjects = new List<GameObject>();
    List<GameObject> patternObjects = new List<GameObject>();



    // Start is called before the first frame update
    /*void Start()
    {
        objects = GameObject.FindGameObjectsWithTag("Properties");

        for(int i = 0; i < objects.Length; i++)
        {
            if(objects[i].GetComponent<ObjectInGame>() != null)
            {
                for(int j = 0; j < objects[i].GetComponent<ObjectInGame>().properties.type.Length; j++)
                {
                    switch(objects[i].GetComponent<ObjectInGame>().properties.type)
                    {
                        case objects[i].GetComponent<ObjectInGame>().properties.property.Color:
                            break;

                    }
                }
            }
        }

        StartCoroutine("PropertyCheck");
    }*/


    //Checks each object with certain properties to see if conditions are met
    IEnumerator PropertyCheck()
    {
        //Checks objects with space property to see if they are still within the room



        yield return new WaitForSeconds(1f);
        StartCoroutine("PropertyCheck");
    }

}
