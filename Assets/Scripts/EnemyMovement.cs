using System.Collections;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float moveSpeed = 2f;
    public Animator animator;
    private Vector3 startingPosition;
    private bool isFacingRight = false;
    [SerializeField] private FieldOfView FieldOfView;
    [SerializeField] private float LookingTime=3f;


    private void Start()
    {
        startingPosition = transform.position;
        StartCoroutine(MoveBackAndForth());
    }

    private void Update()
    {
        FieldOfView.SetOrigin(transform.position);

    }
    private IEnumerator MoveBackAndForth()
    {
        while (true)
        {
            yield return MoveEnemy(Vector3.right, LookingTime);
            yield return new WaitForSeconds(LookingTime);
            yield return MoveEnemy(Vector3.left, LookingTime);
            yield return new WaitForSeconds(LookingTime);
        }
    }

    private IEnumerator MoveEnemy(Vector3 direction, float distance)
    {
        animator.SetBool("isWalking", true);
        float targetPosition = transform.position.x + (direction.x * distance);

        while ((direction == Vector3.right && transform.position.x < targetPosition) ||
               (direction == Vector3.left && transform.position.x > targetPosition))
        {
            transform.position += direction * moveSpeed * Time.deltaTime;



            if (direction == Vector3.right && !isFacingRight)
            {
                Flip();
                FieldOfView.SetAimDirection(direction);
            }
            else if (direction == Vector3.left && isFacingRight)
            {
                Flip();
                FieldOfView.SetAimDirection(direction);

            }

            yield return null;
        }

        animator.SetBool("isWalking", false);
    }

    void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    private void OnDisable()
    {
        animator.SetBool("isWalking", false);
    }
}
