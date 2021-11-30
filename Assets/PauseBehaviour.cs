using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseBehaviour : MonoBehaviour
{
    public GameObject gameUI;
    public GameObject pauseMenu;
    public GameObject retryMenu;

    bool isPaused;

    private void Awake() {
        pauseMenu.SetActive(false);
        retryMenu.SetActive(false);
        isPaused = false;
        Time.timeScale = 1f;
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Escape) && !isPaused)
        {
            PauseGame();
        }
    }

    public void PauseGame()
    {
        Cursor.lockState = CursorLockMode.None;
        gameUI.SetActive(false);
        pauseMenu.SetActive(true);
        retryMenu.SetActive(false);
        Time.timeScale = 0f;
        isPaused = true;
    
    }

    public void GameOverScreen()
    {
        Cursor.lockState = CursorLockMode.None;
        gameUI.SetActive(false);
        pauseMenu.SetActive(false);
        retryMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void RetryGame()
    {
        SceneManager.LoadScene("Level1");
    }

    public void ResumeGame()
    {
        Cursor.lockState = CursorLockMode.Locked;
        gameUI.SetActive(true);
        pauseMenu.SetActive(false);
        retryMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }
}
