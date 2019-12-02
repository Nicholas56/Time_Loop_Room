using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectInGame : MonoBehaviour
{
    public ObjectProperties properties;

    Transform playerPosition;


    // Start is called before the first frame update
    void Start()
    {
        playerPosition = GameObject.FindGameObjectWithTag("Player").transform;
    }

}
