using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneController : MonoBehaviour
{
    [Header("Aircraft Settings")]
    public float maxThrust = 200f;
    public float liftCoefficient = 0.5f;
    public float pitchSensitivity = 1f;
    public float rollSensitivity = 1f;
    public float rudderSensitivity = 1f;
    public float brakePower = 50f;

    [Header("Runtime Values")]
    public float currentThrottle = 0f;
    public float currentPitch = 0f;
    public float currentRoll = 0f;
    public float currentRudder = 0f;
    public bool brakesApplied = false;

    private Rigidbody rb;
    private bool isGrounded = true;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        // Apply engine thrust
        Vector3 thrustVector = transform.forward * (maxThrust * currentThrottle);
        rb.AddForce(thrustVector);

        // Check if on ground
        RaycastHit hit;
        isGrounded = Physics.Raycast(transform.position, -transform.up, out hit, 3f);

        // Apply lift force when moving
        float speed = rb.velocity.magnitude;
        float liftForce = speed * speed * liftCoefficient;
        if (speed > 30) // Minimum speed needed for lift
        {
            rb.AddForce(transform.up * liftForce);
        }

        // Apply control inputs
        rb.AddTorque(transform.right * currentPitch * pitchSensitivity);
        rb.AddTorque(transform.forward * currentRoll * rollSensitivity);

        // Apply rudder
        float rudderEffect = isGrounded ? rudderSensitivity * 2 : rudderSensitivity;
        rb.AddTorque(transform.up * currentRudder * rudderEffect);

        // Apply brakes on ground
        if (isGrounded && brakesApplied)
        {
            rb.velocity *= 0.95f; // Simple brake effect
        }
    }
}
