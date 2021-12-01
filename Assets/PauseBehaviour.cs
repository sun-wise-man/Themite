using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseBehaviour : MonoBehaviour
{
    public GameObject gameUI;
    public GameObject pauseMenu;
    public GameObject retryMenu;
    public GameObject startMenu;
    public GameObject wonMenu;

    GameObject spawner;

    public static bool isPaused;

    private void Start() {
        spawner = GameObject.FindGameObjectWithTag("Spawner");

        Cursor.lockState = CursorLockMode.None;
        gameUI.SetActive(false);
        pauseMenu.SetActive(false);
        retryMenu.SetActive(false);
        startMenu.SetActive(true);
        wonMenu.SetActive(false);
        isPaused = true;
        Time.timeScale = 0f;
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

    public void WonScreen()
    {
        Cursor.lockState = CursorLockMode.None;
        gameUI.SetActive(false);
        wonMenu.SetActive(true);
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

    public void StartGame()
    {
        Cursor.lockState = CursorLockMode.Locked;
        gameUI.SetActive(true);
        startMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
        Invoke("Count", 1f);
    }

    void Count()
    {
        spawner.GetComponent<EnemyController>().CountEnemy();
    }
}
