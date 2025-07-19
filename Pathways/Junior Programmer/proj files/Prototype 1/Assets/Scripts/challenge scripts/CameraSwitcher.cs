using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    public GameObject camera1;
    public GameObject camera2;

    public bool shouldSwitch;

    void Start()
    {
        camera1.SetActive(true);
        camera2.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            camera1.SetActive(!camera1.activeSelf);
            camera2.SetActive(!camera2.activeSelf);
            
            shouldSwitch = !shouldSwitch;
        }
    }
}
