using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public GameObject pausePanel;
    public GameObject inventoryPanel;
    private bool isPaused;
    private bool isPausePanel;
    void Start()
    {
        pausePanel.SetActive(false);
        inventoryPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Pause"))
        {
            if(!inventoryPanel.activeInHierarchy)
            {
                ChangePause();
            }
            else if(inventoryPanel.activeInHierarchy && (!pausePanel.activeInHierarchy))
            {
                inventoryPanel.SetActive(false);
                pausePanel.SetActive(true);
            }
        }
    }

    public void ChangePause()
    {

        isPaused = !isPaused;
        if (isPaused)
        {
            pausePanel.SetActive(true);
            isPausePanel = true;
            Time.timeScale = 0f;
        }
        else
        {
            pausePanel.SetActive(false);
            isPausePanel = false;
            Time.timeScale = 1f;
        }
    }

    public void QuitToMain()
    {
        SceneManager.LoadScene("StartMenu");
    }

    public void SwitchPanel()
    {
        pausePanel.SetActive(false);
        isPausePanel = false;
        inventoryPanel.SetActive(true);
    }

}
