using UnityEngine;
using UnityEngine.InputSystem;

public class RudderController : MonoBehaviour
{
    public PlaneController aircraft;
    public InputActionReference leftThumbstick;
    public float sensitivity = 1.0f;

    void Start()
    {
        leftThumbstick.action.Enable();
    }

    void Update()
    {
        // thumbstick horizontal axis
        Vector2 thumbstickValue = leftThumbstick.action.ReadValue<Vector2>();
        aircraft.currentRudder = thumbstickValue.x * sensitivity;
        transform.localRotation = Quaternion.Euler(0, aircraft.currentRudder * 30f, 0);
    }
}