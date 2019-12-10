using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData : MonoBehaviour
{
    public ObjectProperties[] emptyProperties = new ObjectProperties[10];
    int roomSize = 0;
    public List<ObjectData> segmentIdentifiers;
    public List<GameEvent> actions;

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
