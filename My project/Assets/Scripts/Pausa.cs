using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public GameObject pausePanel;
    private bool isPaused = false;
    public FirstPersonLook cameraController;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (isPaused)
            {
                Resumir();
            }
            else
            {
                Pausa();
            }
        }
    }

    public void Pausa()
    {
        pausePanel.SetActive(true); 
        Time.timeScale = 0f;
        isPaused = true;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        cameraController.enabled = false;
    }

    public void Resumir()
    {
        pausePanel.SetActive(false); 
        Time.timeScale = 1f;      
        isPaused = false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        cameraController.enabled = true;
    }

    public void VolverAlMenu()
    {
        Time.timeScale = 1f; 
        SceneManager.LoadScene("Main Menu");
    }
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("El juego se ha cerrado."); 
    }
}

