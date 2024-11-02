using UnityEngine;

public class Move : MonoBehaviour
{
    public float moveSpeed = 5f; // Speed at which the player moves

    [SerializeField] private FieldOfView FieldOfView;
    void Update()
    {
        // Get input from the horizontal axis (left/right or A/D keys)
        float horizontalInput = Input.GetAxis("Horizontal");

        // Calculate the movement direction
        Vector3 movement = new Vector3(horizontalInput, 0, 0) * moveSpeed * Time.deltaTime;
        FieldOfView.SetAimDirection(movement);
        // Move the player
        transform.Translate(movement);
        FieldOfView.SetOrigin(transform.position);

    }
}
