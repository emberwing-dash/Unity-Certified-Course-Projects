using UnityEngine;

public class FollowPlayer1 : MonoBehaviour
{
    public GameObject player;
    Vector3 offset1;
    Vector3 offset2;

    public CameraSwitcher CS;
    void Start()
    {
        offset1 = new Vector3(0, 5, -7);
        offset2 = new Vector3(0, 4, -2);
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if(CS.shouldSwitch)
        transform.position = player.transform.position + offset2;
        else
        transform.position = player.transform.position + offset1;
    }
}
