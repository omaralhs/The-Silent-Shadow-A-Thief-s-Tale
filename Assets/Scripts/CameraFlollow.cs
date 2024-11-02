using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public float smoothSpeed = 0.05f; 
    public Vector3 offset;

    void FixedUpdate() => transform.position = Vector3.Lerp(transform.position, player.position + offset + new Vector3(0, 0, -10), smoothSpeed);
}
