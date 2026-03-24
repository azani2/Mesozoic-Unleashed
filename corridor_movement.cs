using UnityEngine;
using UnityEngine.InputSystem;

public class corridor_movement : MonoBehaviour
{

    private float moveSpeed = 1.5f;

    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        float moveX = Input.GetAxis("Horizontal"); // A/D or Left/Right arrows

        Vector3 newVelocity = new Vector3(rb.linearVelocity.x, rb.linearVelocity.y, -moveX * moveSpeed); // moves on Z
        rb.linearVelocity = newVelocity;

    }
}

