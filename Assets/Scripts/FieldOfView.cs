using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class FieldOfView : MonoBehaviour
{
    [SerializeField] LayerMask layerMask;
    [SerializeField] LayerMask layerMask2;
    [SerializeField] private Transform player;
    private bool menuIsOpen = false;

    private Mesh mesh;
    private Vector3 origin;
    private float startingAngle;
    [SerializeField] private float viewDistance;
    [SerializeField] private float fov;

    private void Start()
    {
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;
        origin = transform.position; // Assign the class-level variable
    }

    private void LateUpdate()
    {
        int rayCount = 50;
        float angle = startingAngle;
        float angleIncrease = fov / rayCount;

        Vector3[] vertices = new Vector3[rayCount + 2];
        Vector2[] uv = new Vector2[vertices.Length];
        int[] triangles = new int[rayCount * 3];

        vertices[0] = origin;

        int vertexIndex = 1;
        int triangleIndex = 0;
        for (int i = 0; i <= rayCount; i++)
        {
            Vector3 vertex;
            RaycastHit2D raycastHit2D = Physics2D.Raycast(origin, UtilsClass.GetVectorFromAngle(angle), viewDistance, layerMask | layerMask2);

            if (raycastHit2D.collider == null)
            {
                vertex = origin + UtilsClass.GetVectorFromAngle(angle) * viewDistance;
            }
            else
            {
                vertex = raycastHit2D.point;

                // Check if we hit the player
                if (raycastHit2D.collider.transform == player)
                {
                    // Freeze the game
                    Time.timeScale = 0;
                    Debug.Log("Player detected! Game frozen.");
                    if (menuIsOpen==false)
                    {
                        Destroy(gameObject);
                        menuIsOpen = true;
                        FindObjectOfType<Menu>()?.ToggleLostMenu();
                    }
                }
            }

            vertices[vertexIndex] = vertex;

            if (i > 0)
            {
                triangles[triangleIndex + 0] = 0;
                triangles[triangleIndex + 1] = vertexIndex - 1;
                triangles[triangleIndex + 2] = vertexIndex;

                triangleIndex += 3;
            }

            vertexIndex++;
            angle -= angleIncrease;
        }

        mesh.vertices = vertices;
        mesh.uv = uv;
        mesh.triangles = triangles;
    }

    public void SetOrigin(Vector3 origin)
    {
        this.origin = new Vector3(origin.x, origin.y + 1f, origin.z); // Keep the slight offset
    }

    public void SetAimDirection(Vector3 aimDirection)
    {
        startingAngle = UtilsClass.GetAngleFromVector(aimDirection) - fov / 2f;

        // Consider revisiting this condition
        if (startingAngle == -45f)
        {
            startingAngle = 410f;
        }
        else
        {
            startingAngle = 225f;
        }
    }
}
