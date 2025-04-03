using UnityEngine;

public class CockpitManager : MonoBehaviour
{
    public PlaneController aircraft;
    public ThrottleController throttleControl;
    public YokeController yokeControl;
    public RudderController rudderControl;
    public BrakeController brakeControl;

    void Start()
    {
        // Assign references
        throttleControl.aircraft = aircraft;
        yokeControl.aircraft = aircraft;
        rudderControl.aircraft = aircraft;
        brakeControl.aircraft = aircraft;
    }
}