using UnityEngine;

public class Move : MonoBehaviour
{
    public float moveSpeed = 5f; 

    [SerializeField] private FieldOfView FieldOfView;
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        Vector3 movement = new Vector3(horizontalInput, 0, 0) * moveSpeed * Time.deltaTime;
        FieldOfView.SetAimDirection(movement);
        transform.Translate(movement);
        FieldOfView.SetOrigin(transform.position);

    }
}
