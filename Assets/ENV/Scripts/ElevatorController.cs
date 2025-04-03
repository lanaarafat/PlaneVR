using UnityEngine;

public class ElevatorController : MonoBehaviour
{
    public Transform yoke; // Assign the yoke
    public float maxDeflection = 15f; // Max elevator tilt angle

    void Update()
    {
        float pitchAngle = Mathf.Clamp(yoke.localRotation.eulerAngles.x, -maxDeflection, maxDeflection);
        transform.localRotation = Quaternion.Euler(pitchAngle, 0, 0);
    }
}
