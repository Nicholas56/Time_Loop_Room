using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomMaker : MonoBehaviour
{
    public GameObject floorSegment;
    public GameObject player;

    //Allows square rooms from 9 to 81 squares large
    [SerializeField][Range(3,9)] int roomSize = 4;


    public void MakeRoom()
    {
        //The script makes four maps and joins them together
        for (int x = 0; x < roomSize; x++)
        {
            for (int y = 0; y < roomSize; y++)
            {
                GameObject segment = Instantiate(floorSegment, new Vector3((x * 5), 0, (y * 5)), Quaternion.identity);
                segment.transform.SetParent(transform);

                segment.GetComponent<FloorSegmentBehaviour>().floorID = x + y;
            }
        }

        for (int x = 1; x < roomSize; x++)
        {
            for (int y = 1; y < roomSize; y++)
            {
                GameObject segment = Instantiate(floorSegment, new Vector3((x * -5), 0, (y * 5)), Quaternion.identity);
                segment.transform.SetParent(transform);

                segment.GetComponent<FloorSegmentBehaviour>().floorID = x + y;
            }
        }

        for (int x = 1; x < roomSize; x++)
        {
            for (int y = 1; y < roomSize; y++)
            {
                GameObject segment = Instantiate(floorSegment, new Vector3((x * 5), 0, (y * -5)), Quaternion.identity);
                segment.transform.SetParent(transform);

                segment.GetComponent<FloorSegmentBehaviour>().floorID = x + y;
            }
        }

        for (int x = 0; x < roomSize; x++)
        {
            for (int y = 0; y < roomSize; y++)
            {
                GameObject segment = Instantiate(floorSegment, new Vector3((x * -5), 0, (y * -5)), Quaternion.identity);
                segment.transform.SetParent(transform);

                segment.GetComponent<FloorSegmentBehaviour>().floorID = x + y;
            }
        }

        GameObject[] segments = GameObject.FindGameObjectsWithTag("Segment");

        foreach (GameObject segment in segments)
        {
            segment.GetComponent<FloorSegmentBehaviour>().timeForFall = GetComponent<GameManager>().resetTime -(segment.GetComponent<FloorSegmentBehaviour>().floorID*14);
        }

        Instantiate(player, new Vector3(0, 2, 0), Quaternion.identity);
    }


}
