using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    public float rotSpeed = 2f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float input = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up,input * rotSpeed * Time.deltaTime);
    }
}
