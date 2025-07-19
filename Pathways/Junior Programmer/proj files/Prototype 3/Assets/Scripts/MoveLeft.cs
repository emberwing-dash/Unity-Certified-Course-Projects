using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    public float speed = 30f;
    private float leftBound = -15f;

    private PlayerController pC;
    void Start()
    {
        pC = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(pC.gameOver == false)
            transform.Translate(Vector3.left * speed * Time.deltaTime); 

        if(transform.position.x < leftBound && gameObject.CompareTag("Obstacle"))
            Destroy(gameObject);
    }
}
