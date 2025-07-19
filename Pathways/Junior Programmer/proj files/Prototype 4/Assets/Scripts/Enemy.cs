using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    Rigidbody rb;

    GameObject player;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 lookDirection = player.transform.position - transform.position;
        rb.AddForce(lookDirection.normalized * speed);


        if (transform.position.y < -10)
            Destroy(gameObject);
    }
}
