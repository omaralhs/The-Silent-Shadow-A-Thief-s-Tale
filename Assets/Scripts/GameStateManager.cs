using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    public static GameStateManager Instance { get; private set; }
    public enum GameState
    {
        Playing,
        Paused,
        GameOver,
        Win
    }

    public GameState currentState;

    [SerializeField] private GameObject menu; 
    [SerializeField] private GameObject Lostmenu; 
    [SerializeField] private GameObject Won; 


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        ChangeState(GameState.Playing);
    }

    public void ChangeState(GameState newState)
    {
        currentState = newState;

        switch (currentState)
        {
       
            case GameState.Playing:
                StartGame();
                break;
            case GameState.Paused:
                PauseGame();
                break;
            case GameState.GameOver:
                ShowGameOver();
                break;
            case GameState.Win:
                ShowWin();
                break;
        }
    }

   

    private void StartGame()
    {
        menu.SetActive(false);
        Lostmenu.SetActive(false);
        Won.SetActive(false);
        Time.timeScale = 1; 
    }

    private void PauseGame()
    {
        menu.SetActive(true);
        Lostmenu.SetActive(false);
        Won.SetActive(false);
        Time.timeScale = 0; 
    }

    private void ShowGameOver()
    {
        menu.SetActive(false);
        Lostmenu.SetActive(true);
        Won.SetActive(false);
        Time.timeScale = 0; 
    }

    private void ShowWin()
    {
        menu.SetActive(false);
        Lostmenu.SetActive(false);
        Won.SetActive(true);
        Time.timeScale = 0; 
    }
}
