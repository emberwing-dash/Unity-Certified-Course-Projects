using UnityEngine;

public class RotateObject : MonoBehaviour
{
    public float rotationAngle = 45f; // Degrees to rotate each time

    public void rotateLeft()
    {
        transform.Rotate(0, -rotationAngle, 0);
    }

    public void rotateRight()
    {
        transform.Rotate(0, rotationAngle, 0);
    }
}
