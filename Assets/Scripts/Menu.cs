using static GameStateManager;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Menu : MonoBehaviour
{
    [SerializeField] private GameObject Lostmenu; // Game Over menu
    [SerializeField] private GameObject Won; // Win menu

    private void Update()
    {
        // Check for the Escape key press
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("pressed");
            TogglePauseMenu();
        }
    }

    public void ContinueGame()
    {
        GameStateManager.Instance.ChangeState(GameState.Playing);
    }

    public void RestartGame()
    {
        GameStateManager.Instance.ChangeState(GameState.Playing);
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }

    public void ExitGame()
    {
        SceneManager.LoadScene(1); 
    }

    public void TogglePauseMenu()
    {
        if (GameStateManager.Instance.currentState == GameState.Playing)
        {
            Debug.Log("state changed to paused ");
            GameStateManager.Instance.ChangeState(GameState.Paused);
        }
        else if (GameStateManager.Instance.currentState == GameState.Paused)
        {
            GameStateManager.Instance.ChangeState(GameState.Playing);
        }
    }

    public void ToggleLostMenu()
    {
        Lostmenu.SetActive(true);
    }

    public void ToggleWonMenu()
    {
        Won.SetActive(true);
    }
}
