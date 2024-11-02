using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] private GameObject menu; // SerializeField allows you to assign in the Inspector
    [SerializeField] private GameObject Lostmenu; // SerializeField allows you to assign in the Inspector
    [SerializeField] private GameObject Won; // SerializeField allows you to assign in the Inspector

    private void Update()
    {
        // Check for the Escape key press
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ToggleMenu();
        }
    }

    public void ContinueGame()
    {
        menu.SetActive(false);
        Time.timeScale = 1.0f; // Resume the game
    }

    public void RestartGame()
    {
        Time.timeScale = 1;
        Time.timeScale = 1;
        Time.timeScale = 1;
        Time.timeScale = 1;
        Time.timeScale = 1; // Resume the game
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);

    }

    public void ExitGame()
    {
        Time.timeScale = 1; // start the game

        SceneManager.LoadScene(1); // Load the scene with build index 1
    }

    public void ToggleMenu()
    {
        bool isMenuActive = menu.activeSelf; // Use activeSelf instead of active

        if (isMenuActive)
        {
            Debug.Log("Close menu");
            Time.timeScale = 1; // Resume the game
        }
        else
        {
            Debug.Log("Open menu");
            Time.timeScale = 0; // Pause the game
        }

        menu.SetActive(!isMenuActive); // Toggle the menu visibility
    }
    public void ToggleLostMenu()
    {

        Lostmenu.SetActive(true);
    }
    public void ToggleWonMenu()
    {

        Lostmenu.SetActive(true);
    }
}