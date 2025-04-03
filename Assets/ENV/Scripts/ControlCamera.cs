using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlCamera : MonoBehaviour
{
    // Start is called before the first frame update

    public Transform aircraft;
    public Transform cameraMount;
    private void FixedUpdate()
{
    if (aircraft != null && cameraMount != null)
    {
        transform.position = cameraMount.position;
        transform.rotation = cameraMount.rotation;
    }
}
}
