using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDown : MonoBehaviour
{
    public float moveDistance;
    public enum direction { Up, Down, Forward, Backward, Left, Right}
    public direction command;
    public void Reposition()
    {
        switch (command)
        {
            case direction.Up:
                transform.position += new Vector3(0, moveDistance, 0);
                command = direction.Down;
                break;
            case direction.Down:
                transform.position += new Vector3(0, -moveDistance, 0);
                command = direction.Up;
                break;


            case direction.Forward:
                transform.position += new Vector3( moveDistance,0, 0);
                command = direction.Backward;
                break;
            case direction.Backward:
                transform.position += new Vector3(-moveDistance,0, 0);
                command = direction.Forward;
                break;
            case direction.Left:
                transform.position += new Vector3(0, 0, moveDistance);
                command = direction.Right;
                break;
            case direction.Right:
                transform.position += new Vector3(0, 0, -moveDistance);
                command = direction.Left;
                break;
        }
    }
}
