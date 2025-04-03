using UnityEngine;
using UnityEngine.InputSystem;

public class BrakeController : MonoBehaviour
{
    public PlaneController aircraft;
    public InputActionReference rightGripButton;

    void Start()
    {
        rightGripButton.action.Enable();
    }

    void Update()
    {
        aircraft.brakesApplied = rightGripButton.action.ReadValue<float>() > 0.5f;
    }
}