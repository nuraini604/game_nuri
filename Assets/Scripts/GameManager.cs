using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Singleton instance
    public static GameManager Instance { get; private set; }

    [Header("Game Settings")]
    public bool gameIsPaused = false;

    // Awake is called when the script instance is being loaded
    void Awake()
    {
        // Singleton pattern
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        // Initialize game settings
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        // Check for pause input
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }

    // Method to toggle pause state
    public void TogglePause()
    {
        gameIsPaused = !gameIsPaused;
        Time.timeScale = gameIsPaused ? 0 : 1;
        
        // Enable/disable cursor based on pause state
        Cursor.lockState = gameIsPaused ? CursorLockMode.None : CursorLockMode.Locked;
        Cursor.visible = gameIsPaused;
    }

    // Method to restart the current scene
    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    // Method to quit the game
    public void QuitGame()
    {
        Application.Quit();
        
        // For testing in the editor
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}
