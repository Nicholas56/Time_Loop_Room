using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomMaker : MonoBehaviour
{
    GameData data;
    public ObjectProperties[] emptyProperties;
    List<ObjectData> segmentIdentifiers;

    public GameObject floorSegment;
    public GameObject player;

    //Allows square rooms from 9 to 81 squares large
    [SerializeField][Range(3,9)] int roomSize = 4;

    private void Start()
    {
        data = FindObjectOfType<GameData>();

        emptyProperties = data.emptyProperties;
        data.UpdateRoomSize(roomSize);
        //The room maker checks if this data already exists, and if it doesn't it creates new data
        if (data.segmentIdentifiers == null)
        {
                segmentIdentifiers = new List<ObjectData>();            
        }
        else { segmentIdentifiers = data.segmentIdentifiers; }
    }


    public void MakeRoom()
    {
        //If the game data does not exist, the room maker will create every segment from scratch
        //However if it does exist, the segment Identifiers list will be used to create the room instead
        if (data.segmentIdentifiers==null)
        {
            //The script makes four maps and joins them together
            for (int x = 0; x < roomSize; x++)
            {
                for (int y = 0; y < roomSize; y++)
                {
                    GameObject segment = Instantiate(floorSegment, new Vector3((x * 5), 0, (y * 5)), Quaternion.identity);
                    segment.transform.SetParent(transform);

                    segment.GetComponent<FloorSegmentBehaviour>().floorID = x + y;
                    int randNum = Random.Range(0, emptyProperties.Length);
                    segment.GetComponent<ObjectMaker>().givenProperty = emptyProperties[randNum];

                    //The struct is given the pertinent data to be stored in the list
                    ObjectData objectData = new ObjectData();
                    objectData.pos = new Vector3((x * 5), 0, (y * 5));
                    objectData.properties = emptyProperties[randNum];
                    objectData.ID = x + y;

                    segmentIdentifiers.Add(objectData);
                }
            }

            for (int x = 1; x < roomSize; x++)
            {
                for (int y = 1; y < roomSize; y++)
                {
                    GameObject segment = Instantiate(floorSegment, new Vector3((x * -5), 0, (y * 5)), Quaternion.identity);
                    segment.transform.SetParent(transform);

                    segment.GetComponent<FloorSegmentBehaviour>().floorID = x + y;
                    int randNum = Random.Range(0, emptyProperties.Length);
                    segment.GetComponent<ObjectMaker>().givenProperty = emptyProperties[randNum];

                    //The struct is given the pertinent data to be stored in the list
                    ObjectData objectData = new ObjectData();
                    objectData.pos = new Vector3((x * -5), 0, (y * 5));
                    objectData.properties = emptyProperties[randNum];
                    objectData.ID = x + y;

                    segmentIdentifiers.Add(objectData);
                }
            }

            for (int x = 1; x < roomSize; x++)
            {
                for (int y = 1; y < roomSize; y++)
                {
                    GameObject segment = Instantiate(floorSegment, new Vector3((x * 5), 0, (y * -5)), Quaternion.identity);
                    segment.transform.SetParent(transform);

                    segment.GetComponent<FloorSegmentBehaviour>().floorID = x + y;
                    int randNum = Random.Range(0, emptyProperties.Length);
                    segment.GetComponent<ObjectMaker>().givenProperty = emptyProperties[randNum];

                    //The struct is given the pertinent data to be stored in the list
                    ObjectData objectData = new ObjectData();
                    objectData.pos = new Vector3((x * 5), 0, (y * -5));
                    objectData.properties = emptyProperties[randNum];
                    objectData.ID = x + y;

                    segmentIdentifiers.Add(objectData);
                }
            }

            for (int x = 0; x < roomSize; x++)
            {
                for (int y = 0; y < roomSize; y++)
                {
                    GameObject segment = Instantiate(floorSegment, new Vector3((x * -5), 0, (y * -5)), Quaternion.identity);
                    segment.transform.SetParent(transform);

                    segment.GetComponent<FloorSegmentBehaviour>().floorID = x + y;
                    int randNum = Random.Range(0, emptyProperties.Length);
                    segment.GetComponent<ObjectMaker>().givenProperty = emptyProperties[randNum];

                    //The struct is given the pertinent data to be stored in the list
                    ObjectData objectData = new ObjectData();
                    objectData.pos = new Vector3((x * -5), 0, (y * -5));
                    objectData.properties = emptyProperties[randNum];
                    objectData.ID = x + y;

                    segmentIdentifiers.Add(objectData);
                }
            }
            //Stores all the data in Game Data
            data.segmentIdentifiers = segmentIdentifiers;

            GameObject[] segments = GameObject.FindGameObjectsWithTag("Segment");

            //Sets the amount of time before the segment falls, based on the ID which reflects the order it was made in, and the total loop time
            foreach (GameObject segment in segments)
            {
                segment.GetComponent<FloorSegmentBehaviour>().timeForFall = GetComponent<GameManager>().resetTime - (segment.GetComponent<FloorSegmentBehaviour>().floorID * 14);
            }
        }
        else
        {
            foreach(ObjectData data in segmentIdentifiers)
            {
                GameObject segment = Instantiate(floorSegment, data.pos, Quaternion.identity);
                segment.transform.SetParent(transform);
                segment.GetComponent<FloorSegmentBehaviour>().floorID = data.ID;
                segment.GetComponent<ObjectMaker>().givenProperty = data.properties;
                segment.GetComponent<FloorSegmentBehaviour>().timeForFall = GetComponent<GameManager>().resetTime - (data.ID * 14);
            }
        }
        Instantiate(player, new Vector3(0, 2, 0), Quaternion.identity);
    }


}

 public struct ObjectData
{
    public Vector3 pos;
    public ObjectProperties properties;
    public int ID;
    public float fallTime;
}
