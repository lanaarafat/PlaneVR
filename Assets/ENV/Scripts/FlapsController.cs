using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class FlapsController : MonoBehaviour
{
    public float[] flapAngles = { 0, 10, 20, 30 }; // Define flap angles
    private int currentFlapIndex = 0;

    public void IncreaseFlaps()
    {
        if (currentFlapIndex < flapAngles.Length - 1)
        {
            currentFlapIndex++;
            ApplyFlapPosition();
        }
    }

    public void DecreaseFlaps()
    {
        if (currentFlapIndex > 0)
        {
            currentFlapIndex--;
            ApplyFlapPosition();
        }
    }

    private void ApplyFlapPosition()
    {
        transform.localRotation = Quaternion.Euler(flapAngles[currentFlapIndex], 0, 0);
    }
}
