using UnityEngine;

public class AileronController : MonoBehaviour
{
    public Transform yoke; // Assign the yoke
    public float maxDeflection = 15f; // Max rotation angle

    void Update()
    {
        float rollAngle = Mathf.Clamp(yoke.localRotation.eulerAngles.z, -maxDeflection, maxDeflection);
        transform.localRotation = Quaternion.Euler(0, 0, rollAngle);
    }
}
