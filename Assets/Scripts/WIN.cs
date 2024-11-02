using UnityEngine;

public class TrophyWinTrigger : MonoBehaviour
{
    public GameObject player; 

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == player) 
        {
            Debug.Log("Player touched the trophy. You won!");
            gameObject.SetActive(false);
            Time.timeScale = 0; // Freeze the game
            FindObjectOfType<Menu>()?.ToggleWonMenu();


        }
    }
}
