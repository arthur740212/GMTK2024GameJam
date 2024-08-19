using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPlayerController : MonoBehaviour
{
    public float movementSpeed = 10f;
    public float rotationSpeed = 10f;
    public float forceDecay = 10f;
    public float gravityFactor = 15f;

    private Rigidbody rigidBody;
    private Vector3 forward;
    private Vector3 right;
    private Vector3 externalForce;

    void Awake()
    {
        rigidBody = GetComponent<Rigidbody>();
        forward = Camera.main.transform.forward;
        right = Camera.main.transform.right;
        forward.y = 0;
        right.y = 0;
        forward.Normalize();
        right.Normalize();
    }

    void Update()
    {
        // Input velocity is stable
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 moveDirection = (forward * vertical + right * horizontal).normalized;
        Vector3 velocity = moveDirection * movementSpeed;
        rigidBody.velocity = velocity;

        // Forces by environment is unstable
        rigidBody.AddForce(new Vector3(0, -1, 0) * gravityFactor, ForceMode.Acceleration); 
        rigidBody.AddForce(externalForce, ForceMode.Impulse);
        externalForce = Vector3.Lerp(externalForce, Vector3.zero, Time.deltaTime * forceDecay); // Dampen down over time

        // Use transform rotation
        if(moveDirection!=Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }

    public void ApplyExternalForce(Vector3 force)
    {
        externalForce += force;
    }
}
