using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorSegmentBehaviour : MonoBehaviour
{
    public float timeForFall;
    bool willFall;
    public int floorID;

    [SerializeField]
    Material[] floorStates = new Material[3];

    // Start is called before the first frame update
    void Start()
    {
        willFall = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (willFall)
        {
            if (GameManager.gameTimer < (timeForFall - 5))
            {
                gameObject.GetComponent<Renderer>().material = floorStates[0];
            }
            else if (GameManager.gameTimer < timeForFall)
            {
                gameObject.GetComponent<Renderer>().material = floorStates[1];
            }
            else
            {
                gameObject.GetComponent<Renderer>().material = floorStates[2];
                Fall();
            }
        }
    }

    void Fall()
    {
        transform.Translate(Vector3.down);
    }
}
