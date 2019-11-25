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


    // Start is called before the first frame update
    void Start()
    {
        //The reset will occur after the time input has passed
        Invoke("ResetTime", resetTime);
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
