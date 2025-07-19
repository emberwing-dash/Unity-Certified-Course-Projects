using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 20f;

    public float turnSpeed = 45f;
    public float horizontalInput;
    public float verticalInput;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        transform.Translate(Vector3.forward * speed * Time.deltaTime   * verticalInput);
        //transform.Translate(Vector3.right * turnSpeed * Time.deltaTime * horizontalInput);
        transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime * horizontalInput);
    }
}
