using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsScript : MonoBehaviour
{
    public GameObject pausePanel;

    public static bool isPaused;
    AudioSource music;

    // Start is called before the first frame update
    void Start()
    {
        isPaused = false;
        pausePanel.SetActive(false);
        music = FindObjectOfType<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //Upon pressing the escape key, the time is stopped and the pause menu is brought up. The music is also paused.
        if (Input.GetKeyDown(KeyCode.Escape)&&!isPaused)
        {
            Time.timeScale = 0;
            isPaused = true;
            music.Pause();
            pausePanel.SetActive(true);
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 1;
            isPaused = false;
            music.Play();
            pausePanel.SetActive(false);
        }
    }
}
