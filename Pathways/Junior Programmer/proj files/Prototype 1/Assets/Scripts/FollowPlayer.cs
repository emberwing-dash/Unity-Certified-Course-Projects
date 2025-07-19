using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;
    public Vector3 offset = new Vector3(0, 5, -7);

    void Start()
    {
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = player.transform.position + offset; 
    }
}
