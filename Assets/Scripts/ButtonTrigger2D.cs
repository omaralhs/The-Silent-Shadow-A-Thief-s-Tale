using UnityEngine;
using System;

public class ButtonTrigger2D : MonoBehaviour
{
    public GameObject wall;
    private bool isPressed = false;

    public event Action OnWallReappear;

    private void Start()
    {
        OnWallReappear += ReappearWall;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (!isPressed)
            {
                wall.SetActive(true);
                isPressed = true;
                Invoke("TriggerReappearEvent", 10f);
            }
        }
    }

    private void TriggerReappearEvent()
    {
        OnWallReappear?.Invoke();
        isPressed = false;
    }

    private void ReappearWall()
    {
        wall.SetActive(false);
    }

    private void OnDestroy()
    {
        OnWallReappear -= ReappearWall;
    }
}
