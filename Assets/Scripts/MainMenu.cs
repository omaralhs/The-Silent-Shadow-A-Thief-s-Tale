using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static GameStateManager;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        GameStateManager.Instance.ChangeState(GameState.Playing);

    }
    public void ExitGame()
    {
        Application.Quit();
    }
}