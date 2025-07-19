using UnityEngine;

public class Target : MonoBehaviour
{
    public ParticleSystem explosion;

    private Rigidbody targetRb;
    private GameManager gM;

    private float minSpeed = 12f;
    private float maxSpeed = 16f;
    private float maxTorque = 10;
    private float xRange = 4;
    private float ySpawnPos = -6;

    void Start()
    {
        targetRb = GetComponent<Rigidbody>();

        targetRb.AddForce(RandomForce(), ForceMode.Impulse);
        targetRb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(),    ForceMode.Impulse);

        transform.position = RandomSpawnPos();

        gM = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(minSpeed, maxSpeed);
    }

    float RandomTorque()
    {
        return Random.Range(-maxTorque, maxTorque);
    }

    Vector3 RandomSpawnPos()
    {
        return new Vector3(Random.Range(-xRange, xRange), ySpawnPos);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        if (gM.isGameActive)
        {
            gM.UpdateScore(5);
            Instantiate(explosion, transform.position, explosion.transform.rotation);
            Destroy(gameObject);
        }

        

    }



    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        if (!gameObject.CompareTag("Bad"))
        {
            gM.GameOver();
        }
    }
}
