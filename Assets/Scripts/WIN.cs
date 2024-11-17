using UnityEngine;
using static GameStateManager;

public class WIN : MonoBehaviour
{
    public GameObject player;

    public delegate void GemCollectedEventHandler();
    public event GemCollectedEventHandler OnGemCollected;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            OnGemCollected?.Invoke();

            Destroy(gameObject);
        }
    }
}