using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using System.Collections;

public class ThrottleController : MonoBehaviour
{
    public Transform startPosition; // Idle throttle position
    public Transform endPosition;   // Full throttle position
    public PlaneController aircraft; // Aircraft script reference

    private XRGrabInteractable grabInteractable;
    private Vector3 moveDirection;
    private float maxDistance;

    void Start()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();

        // Calculate the movement direction and max distance
        moveDirection = (endPosition.localPosition - startPosition.localPosition).normalized;
        maxDistance = Vector3.Distance(startPosition.localPosition, endPosition.localPosition);

        grabInteractable.selectExited.AddListener(OnReleased);
    }

    void Update()
    {
        if (grabInteractable.isSelected)
        {
            // Get current position projected onto movement axis
            Vector3 currentOffset = transform.localPosition - startPosition.localPosition;
            float currentDistance = Vector3.Dot(currentOffset, moveDirection);
            currentDistance = Mathf.Clamp(currentDistance, 0, maxDistance);

            // Restrict movement to our axis
            transform.localPosition = startPosition.localPosition + moveDirection * currentDistance;

            // Update aircraft throttle value (0-1)
            aircraft.currentThrottle = currentDistance / maxDistance;
        }
    }

    public void OnReleased(SelectExitEventArgs args)
    {
        StartCoroutine(ResetThrottlePosition());
    }

    IEnumerator ResetThrottlePosition()
    {
        Vector3 start = transform.localPosition;
        float elapsedTime = 0f;
        float duration = 0.3f; // Adjust for smoother return

        while (elapsedTime < duration)
        {
            transform.localPosition = Vector3.Lerp(start, startPosition.localPosition, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.localPosition = startPosition.localPosition; // Ensure exact reset
        aircraft.currentThrottle = 0f; // Set throttle to idle
    }
}
