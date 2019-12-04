using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //The timer will be used to tell the rest of the game what time it is
    public static float gameTimer = 0f;

    //The time before the scene reloads
    public float resetTime = 300f;

    GameObject[] objects;   //Array containing every object in the game
    public static List<GameObject> spaceObjects = new List<GameObject>();
    public static List<GameObject> lineObjects = new List<GameObject>();
    public static List<GameObject> formObjects = new List<GameObject>();
    public static List<GameObject> lightObjects = new List<GameObject>();
    public static List<GameObject> colorObjects = new List<GameObject>();
    public static List<GameObject> textureObjects = new List<GameObject>();
    public static List<GameObject> patternObjects = new List<GameObject>();


    // Start is called before the first frame update
    void Start()
    {
        //The reset will occur after the time input has passed
        Invoke("ResetTime", resetTime);

        objects = GameObject.FindGameObjectsWithTag("Properties");

        //This will go through every object in the game with the tag properties and sort it into lists depending it's property type
        //Some objects will have more than one property type and therefore will appear in multiple lists.
        for (int i = 0; i < objects.Length; i++)
        {
            if (objects[i].GetComponent<ObjectInGame>())
            {
                for (int j = 0; j < objects[i].GetComponent<ObjectInGame>().properties.type.Length; j++)
                {
                    switch (objects[i].GetComponent<ObjectInGame>().properties.type[j])
                    {
                        case ObjectProperties.property.Color:
                            colorObjects.Add(objects[i]);
                            break;
                        case ObjectProperties.property.Form:
                            formObjects.Add(objects[i]);
                            break;
                        case ObjectProperties.property.Light:
                            lightObjects.Add(objects[i]);
                            break;
                        case ObjectProperties.property.Line:
                            lineObjects.Add(objects[i]);
                            break;
                        case ObjectProperties.property.Pattern:
                            patternObjects.Add(objects[i]);
                            break;
                        case ObjectProperties.property.Space:
                            spaceObjects.Add(objects[i]);
                            break;
                        case ObjectProperties.property.Texture:
                            textureObjects.Add(objects[i]);
                            break;
                        default:
                            break;
                    }
                }
            }
        }
    }

    private void Update()
    {
        //The game timer will increase with time
        gameTimer += Time.deltaTime;
    }

    void ResetTime()
    {
        //The scene will be reloaded to reset
        SceneManager.LoadScene(0);
    }

}
