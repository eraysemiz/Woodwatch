using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    private Rigidbody rb;
    private Vector3 inputDirection;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal"); // A/D or Left/Right
        float v = Input.GetAxisRaw("Vertical");   // W/S or Up/Down

        // Ýzometrik kamera için yönleri çapraz hizala
        Vector3 right = Quaternion.Euler(0, 45, 0) * Vector3.right;
        Vector3 forward = Quaternion.Euler(0, 45, 0) * Vector3.forward;

        inputDirection = (right * h + forward * v).normalized;
    }

    void FixedUpdate()
    {
        rb.linearVelocity = inputDirection * moveSpeed;
    }
}
