using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class TankMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rotateSpeed = 100f;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float move = Input.GetAxis("Vertical") * moveSpeed * Time.fixedDeltaTime;
        float rotate = Input.GetAxis("Horizontal") * rotateSpeed * Time.fixedDeltaTime;

        // Movimiento físico
        Vector3 newPosition = rb.position + transform.forward * move;
        Quaternion newRotation = rb.rotation * Quaternion.Euler(0f, rotate, 0f);

        rb.MovePosition(newPosition);
        rb.MoveRotation(newRotation);
    }
}
