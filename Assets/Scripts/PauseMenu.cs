using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class PauseMenu : MonoBehaviour
{
    // Get a reference to the pause menu object    
    public GameObject pauseMenu;
    public MainShipController menuUIControls;
    //public GameObject thePauseMenu;
    //public GameObject theMusicMenu;

    // Public Static bool so other scripts can reference and make sure game is not paused
    public static bool isPaused = false;
    public Button primaryButton;
    //public Button onButton;
    // Start is called before the first frame update

    void Awake()
    {
        menuUIControls = new MainShipController();
    }

    void Start()
    {
        pauseMenu.SetActive(false);
    }

    public void PressStart(InputAction.CallbackContext cntx)
    {
        if (RaidenHealthController.instance.currentHealth > 0)
        {
            // If game is paused, then resume the game
            if (isPaused)
            {
                ResumeGame();
            }
            // Else game is playing so pause the game
            else
            {
                PauseGame();
            }
        }
        
    }

    public void PauseGame()
    {
         // Play pause SFX
        AudioManager.instance.PlaySFX(21);

        // Activate the pause menu
        //EventSystem.current.SetSelectedGameObject(null);
        
        pauseMenu.SetActive(true);
        
        EventSystem.current.SetSelectedGameObject(null);
        primaryButton.Select();
    

        // Set timescale to zero so nothing gets updated
        Time.timeScale = 0f;

        // Game is now paused
        isPaused = true;
        AudioManager.instance.PauseBGM();
    }

    public void ResumeGame()
    {
        // Play resume SFX
        AudioManager.instance.PlaySFX(21);

        // Deactivate the pause menu
        EventSystem.current.SetSelectedGameObject(null);
        pauseMenu.SetActive(false);
        //theMusicMenu.SetActive(false);

        // Set timescale back to 1 so we update normally
        Time.timeScale = 1f;

        // Game is now unpaused 
        isPaused = false;
        AudioManager.instance.ContinueBGM();
    }

    public void GoToMainMenu()
    {
        // Application.Quit();
        EventSystem.current.SetSelectedGameObject(null);
        isPaused = false;
        Time.timeScale = 1f;
        AudioManager.instance.PlaySFX(22);

        AudioManager.instance.StopBGM();
        SceneManager.LoadScene("Main Menu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    void OnEnable()
    { 
        menuUIControls.UIMenu.Enable();
        menuUIControls.UIMenu.Start.performed += PressStart;
        //RandomButton.Select();
    }

    void OnDisable()
    {
        menuUIControls.UIMenu.Disable();
        menuUIControls.UIMenu.Start.performed -= PressStart; 
    }

}
