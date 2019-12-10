using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RoomMaker : MonoBehaviour
{
    GameData data;
    public ObjectProperties[] emptyProperties;
    List<ObjectData> segmentIdentifiers;
    List<UnityEvent> actions;

    public GameObject floorSegment;
    public GameObject player;

    //Allows square rooms from 9 to 81 squares large
    [SerializeField][Range(3,9)] int roomSize = 4;

    private void Start()
    {
        data = FindObjectOfType<GameData>();
                
        data.UpdateRoomSize(roomSize);
        //The room maker checks if this data already exists, and if it doesn't it creates new data
        if (data.segmentIdentifiers == null)
        {
                segmentIdentifiers = new List<ObjectData>();            
        }
        else { segmentIdentifiers = data.segmentIdentifiers; }

        //The room maker has to check if list of events already exists, if not it will create its own
        if (GameData.actions == null)
        {
            actions = new List<UnityEvent>();
            for(int i = 0; i< roomSize * roomSize; i++)
            {
                UnityEvent loopEvent = new UnityEvent();
                actions.Add(loopEvent);
            }
        }
        else { actions = GameData.actions; }

        //The room maker checks if the properties exist, otherwise makes it's own
        if (data.emptyProperties == null)
        {
            emptyProperties = new ObjectProperties[data.emptyProperties.Length];
            for (int i = 0; i < data.emptyProperties.Length; i++)
            {
                emptyProperties[i] = new ObjectProperties(new List<UnityEvent>(), new ObjectProperties.property[2]);
                emptyProperties[i].events.Add(actions[i]);
                emptyProperties[i].type[0] = emptyProperties[i].AddRandomType();
                emptyProperties[i].type[1] = emptyProperties[i].AddRandomType();
            }
        }
        emptyProperties = data.emptyProperties;
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
                    //Give the segment a random properties component
                    int randNum = Random.Range(0, emptyProperties.Length);
                    segment.GetComponent<ObjectMaker>().givenProperty = new ObjectProperties(emptyProperties[randNum].events, emptyProperties[randNum].type);
                    //Give the properties an event from the action list
                    int randNum2 = Random.Range(0, actions.Count);
                    segment.GetComponent<ObjectMaker>().givenProperty.events.Add(actions[randNum2]);

                    //The struct is given the pertinent data to be stored in the list
                    ObjectData objectData = new ObjectData();
                    objectData.pos = new Vector3((x * 5), 0, (y * 5));
                    objectData.properties = emptyProperties[randNum];
                    objectData.ID = x + y;
                    objectData.action = actions[randNum2];

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
                    segment.GetComponent<ObjectMaker>().givenProperty = new ObjectProperties(emptyProperties[randNum].events, emptyProperties[randNum].type);
                    int randNum2 = Random.Range(0, actions.Count);
                    segment.GetComponent<ObjectMaker>().givenProperty.events.Add(actions[randNum2]);

                    //The struct is given the pertinent data to be stored in the list
                    ObjectData objectData = new ObjectData();
                    objectData.pos = new Vector3((x * -5), 0, (y * 5));
                    objectData.properties = emptyProperties[randNum];
                    objectData.ID = x + y;
                    objectData.action = actions[randNum2];

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
                    segment.GetComponent<ObjectMaker>().givenProperty = new ObjectProperties(emptyProperties[randNum].events, emptyProperties[randNum].type);
                    int randNum2 = Random.Range(0, actions.Count);
                    segment.GetComponent<ObjectMaker>().givenProperty.events.Add(actions[randNum2]);

                    //The struct is given the pertinent data to be stored in the list
                    ObjectData objectData = new ObjectData();
                    objectData.pos = new Vector3((x * 5), 0, (y * -5));
                    objectData.properties = emptyProperties[randNum];
                    objectData.ID = x + y;
                    objectData.action = actions[randNum2];

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
                    segment.GetComponent<ObjectMaker>().givenProperty = new ObjectProperties(emptyProperties[randNum].events, emptyProperties[randNum].type);
                    int randNum2 = Random.Range(0, actions.Count);
                    segment.GetComponent<ObjectMaker>().givenProperty.events.Add(actions[randNum2]);

                    //The struct is given the pertinent data to be stored in the list
                    ObjectData objectData = new ObjectData();
                    objectData.pos = new Vector3((x * -5), 0, (y * -5));
                    objectData.properties = emptyProperties[randNum];
                    objectData.ID = x + y;
                    objectData.action = actions[randNum2];

                    segmentIdentifiers.Add(objectData);
                }
            }
            //Stores all the data in Game Data
            data.segmentIdentifiers = segmentIdentifiers;
            GameData.actions = actions;

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
                segment.GetComponent<ObjectMaker>().givenProperty = new ObjectProperties(data.properties.events, data.properties.type);
                segment.GetComponent<ObjectMaker>().givenProperty.events.Add(data.action);
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
    public UnityEvent action;
}
