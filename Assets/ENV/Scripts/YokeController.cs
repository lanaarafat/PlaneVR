using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class YokeController : MonoBehaviour
{
    public PlaneController aircraft;
    public float maxPitchAngle = 15f;
    public float maxRollAngle = 90f;
    public Transform restPosition;

    private XRGrabInteractable grabInteractable;
    private Vector3 initialPosition;
    private Quaternion initialRotation;

    void Start()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();
        initialPosition = transform.localPosition;
        initialRotation = transform.localRotation;

        grabInteractable.selectExited.AddListener(OnReleased);
    }

    void Update()
    {
        if (grabInteractable.isSelected)
        {
            // Calculate pitch from forward/backward movement
            float pitchOffset = transform.localPosition.z - initialPosition.z;
            float pitchNormalized = Mathf.Clamp(pitchOffset / 0.1f, -1f, 1f); // 10cm movement range
            aircraft.currentPitch = pitchNormalized * maxPitchAngle;

            // Get roll from yoke rotation around z axis
            float currentZAngle = transform.localEulerAngles.z;
            if (currentZAngle > 180f) currentZAngle -= 360f;

            float rollNormalized = Mathf.Clamp(currentZAngle / maxRollAngle, -1f, 1f);
            aircraft.currentRoll = rollNormalized * maxRollAngle;

            // Restrict movement range
            Vector3 restrictedPosition = initialPosition;
            restrictedPosition.z += pitchOffset;
            transform.localPosition = restrictedPosition;
        }
    }

    public  void OnReleased(SelectExitEventArgs args)
    {
        // Return to center when released
        if (!grabInteractable.isSelected)
        {
            // Optional: Add smooth return to center
            transform.localPosition = initialPosition;
            transform.localRotation = initialRotation;
            aircraft.currentPitch = 0f;
            aircraft.currentRoll = 0f;
        }
    }
}