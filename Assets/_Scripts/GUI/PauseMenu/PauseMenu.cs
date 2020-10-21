using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public GameObject pausePanel;
    public bool isPaused;
    // Start is called before the first frame update
    void Awake()
    {
        isPaused = false;
        pausePanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(isPaused)
            {
                Resume();
            } else
            {
                Pause();
            }
        }
    }
    void Resume()
    {
        Time.timeScale = 1;
        pausePanel.SetActive(false);
        isPaused = false;
    }
    void Pause()
    {
        Time.timeScale = 0;
        pausePanel.SetActive(true);
        isPaused = true;
    }
}
