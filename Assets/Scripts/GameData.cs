using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameData : MonoBehaviour
{
    public ObjectProperties[] emptyProperties = new ObjectProperties[10];
    int roomSize = 0;
    public List<ObjectData> segmentIdentifiers;
    public static List<UnityEvent> actions;
    public static Dictionary<Vector3, UnityEvent> listeners;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateRoomSize(int newRoomSize)
    {
        if (roomSize == 0)
        {
            roomSize = newRoomSize;
        }
    }
}
