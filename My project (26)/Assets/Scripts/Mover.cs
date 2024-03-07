using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;

    private const string Horizontal = nameof(Horizontal);
    private const string Vertical = nameof(Vertical);

    Vector3 distance = Vector3.zero;

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        float verticalDirection = Input.GetAxisRaw("Vertical");
        Vector3 verticalDistance = verticalDirection * _moveSpeed * Time.deltaTime * Vector3.up;

        float horizontalDirection = Input.GetAxisRaw("Horizontal");
        Vector3 horizontalDistance = horizontalDirection * _moveSpeed * Time.deltaTime * Vector3.right;

        Vector3 distance = verticalDistance + horizontalDistance;
        transform.Translate(distance);        
    }
}
