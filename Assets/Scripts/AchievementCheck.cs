using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievementCheck : MonoBehaviour
{  
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("PropertyCheck");
    }

    //Checks each object with certain properties to see if conditions are met
    IEnumerator PropertyCheck()
    {
        {//Checks objects with space property to see if they are still within the room and updates the Space value
            int spaceNum = 0;
            
            for (int i = 0; i < GameManager.spaceObjects.Count; i++)
            {
                if (GameManager.spaceObjects[i].transform.position.y < 0)
                {
                    spaceNum++;
                }
            }
            int differ = spaceNum - Properties.Space;
            Properties.Increase("Space", differ);
        }

        {//Checks objects with line property

        }

        {//Checks objects with form property

        }

        {//Checks objects with light property

        }

        {//Checks objects with color property

        }

        {//Checks objects with texture property

        }

        {//Checks objects with pattern property

        }

        print("There are " + Properties.Space + " points in Space");

        yield return new WaitForSeconds(1f);
        StartCoroutine("PropertyCheck");
    }

}
