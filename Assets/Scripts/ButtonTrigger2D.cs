using UnityEngine;

public class ButtonTrigger2D : MonoBehaviour
{
    public GameObject wall; 
    private bool isPressed = false; 

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !isPressed)
        {
            Debug.Log("Button pressed, wall appears");
            wall.SetActive(true); 
            isPressed = true; 
        }
    }
}
