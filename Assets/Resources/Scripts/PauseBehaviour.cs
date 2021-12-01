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
        
        // Find spawner for counting enemies
        spawner = GameObject.FindGameObjectWithTag("Spawner");

        // !Lock Cursor
        Cursor.lockState = CursorLockMode.None;
        
        // Display appropriately
        gameUI.SetActive(false);
        pauseMenu.SetActive(false);
        retryMenu.SetActive(false);
        startMenu.SetActive(true);
        wonMenu.SetActive(false);
        
        // Set game to paused
        isPaused = true;
        Time.timeScale = 0f;
    }

    private void Update() {
        // 'Escape' for pausing
        if (Input.GetKeyDown(KeyCode.Escape) && !isPaused)
        {
            PauseGame();
        }
    }

    public void PauseGame()
    {
        // Cursor to !Lock
        Cursor.lockState = CursorLockMode.None;
        
        // Display appropriately
        gameUI.SetActive(false);
        pauseMenu.SetActive(true);
        retryMenu.SetActive(false);
        
        // Set game to paused
        isPaused = true;
        Time.timeScale = 0f;
    
    }

    // Method for Retry button
    public void RetryGame()
    {
        SceneManager.LoadScene("Level1");
    }

    // Method for Resume button
    public void ResumeGame()
    {
        Cursor.lockState = CursorLockMode.Locked;
     
        gameUI.SetActive(true);
        pauseMenu.SetActive(false);
        retryMenu.SetActive(false);
     
        isPaused = false;
        Time.timeScale = 1f;
    }

    // Method for Start button
    public void StartGame()
    {
        Cursor.lockState = CursorLockMode.Locked;
     
        gameUI.SetActive(true);
        startMenu.SetActive(false);
        
        // Game starting
        isPaused = false;
        Time.timeScale = 1f;

        // Call 'Count' method in 1 second
        Invoke("Count", 1f);
    }

    // Method for calling gameover screen
    public void GameOverScreen()
    {
        Cursor.lockState = CursorLockMode.None;
        
        gameUI.SetActive(false);
        pauseMenu.SetActive(false);
        retryMenu.SetActive(true);
        
        isPaused = true;
        Time.timeScale = 0f;
    }

    // Method for calling won screen
    public void WonScreen()
    {
        Cursor.lockState = CursorLockMode.None;
        
        gameUI.SetActive(false);
        wonMenu.SetActive(true);
        
        isPaused = true;
        Time.timeScale = 0f;
    }

    void Count()
    {
        // Count enemy
        spawner.GetComponent<EnemyController>().CountEnemy();
    }
}