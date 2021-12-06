using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class UIBehaviour : MonoBehaviour
{
    public GameObject missionDisplay;
    public GameObject gameUI;
    public GameObject pauseMenu;
    public GameObject retryMenu;
    public GameObject startMenu;
    public GameObject wonMenu;
    public GameObject savedText;

    public TMP_Text wonText;

    public static bool isPaused;
    public static bool enemyBool = false;
    public static bool villagerBool = false;

    private void Start() 
    {
        // Cursor visibility
        Cursor.visible = true;

        // !Lock Cursor
        Cursor.lockState = CursorLockMode.None;
        
        // Display appropriately
        gameUI.SetActive(false);
        pauseMenu.SetActive(false);
        retryMenu.SetActive(false);
        startMenu.SetActive(true);
        wonMenu.SetActive(false);
        missionDisplay.SetActive(false);
        
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
        Cursor.visible = true;

        // Cursor to !Lock
        Cursor.lockState = CursorLockMode.None;
        
        // Display appropriately
        gameUI.SetActive(false);
        pauseMenu.SetActive(true);
        retryMenu.SetActive(false);
        missionDisplay.SetActive(false);
        
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
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
     
        gameUI.SetActive(true);
        pauseMenu.SetActive(false);
        retryMenu.SetActive(false);
        missionDisplay.SetActive(true);
     
        isPaused = false;
        Time.timeScale = 1f;
    }

    // Method for Start button
    public void StartGame()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        
        gameUI.SetActive(true);
        startMenu.SetActive(false);
        
        // Game starting
        isPaused = false;
        Time.timeScale = 1f;

        // Call 'Count' method in 1 second
        Invoke("Count", 1f);
        Invoke("DisplayMission", .5f);
    }

    // Method for calling gameover screen
    public void GameOverScreen()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        
        gameUI.SetActive(false);
        pauseMenu.SetActive(false);
        retryMenu.SetActive(true);
        missionDisplay.SetActive(false);
        
        isPaused = true;
        Time.timeScale = 0f;
    }

    // Method for calling won screen
    public void WonScreen()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        if(enemyBool) wonText.text = "You defeated all the enemies";
        if(villagerBool) wonText.text = "You saved all the villagers";
        
        gameUI.SetActive(false);
        wonMenu.SetActive(true);
        missionDisplay.SetActive(false);
        savedText.SetActive(false);
        
        isPaused = true;
        Time.timeScale = 0f;
    }

    void Count()
    {
        // Count enemy
        FindObjectOfType<EnemyController>().CountEnemy();

        // Count villager
        FindObjectOfType<VillagerCounter>().CountVillager();
    }

    void DisplayMission()
    {
        missionDisplay.SetActive(true);
    }
    
    public void SavedVillager()
    {
        savedText.SetActive(true);

        Invoke("HideSavedVillager", 2f);
    }

    void HideSavedVillager()
    {
        savedText.SetActive(false);
    }

}
