using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class MainMenu : MonoBehaviour
{
    // Get a reference to the pause menu object
    public static GameOverMenu instance;    
    public GameObject gameOverMenu;
    public MainShipController menuUIControls;
    //public GameObject thePauseMenu;
    //public GameObject theMusicMenu;

    // Public Static bool so other scripts can reference and make sure game is not paused
    public static bool isPaused = false;
    public Button primaryButton;
    //public Button onButton;
    // Start is called before the first frame update
    // Start is called before the first frame update
    void Awake()
    {
        menuUIControls = new MainShipController();
    }
    void Start()
    {
        gameOverMenu.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartTheGame()
    {
        // Play resume SFX
        //AudioManager.instance.PlaySFX(21);

        // Deactivate the pause menu
        EventSystem.current.SetSelectedGameObject(null);
        gameOverMenu.SetActive(false);
        //theMusicMenu.SetActive(false);

        // Set timescale back to 1 so we update normally
        Time.timeScale = 1f;

        // Game is now unpaused 
        isPaused = false;
        SceneManager.LoadScene("Level 001");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
