using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject obstaclePrefab;
    public Vector3 spawnPos;

    private float startRate;
    private float repeatRate;

    private PlayerController pC;
    void Start()
    {
        spawnPos = transform.position;

        startRate = 0;
        repeatRate = 3;

        pC = GameObject.Find("Player").GetComponent<PlayerController>();

        InvokeRepeating("spawnObstacle",startRate,repeatRate);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void spawnObstacle()
    {
        if (pC.gameOver == false)
        Instantiate(obstaclePrefab, spawnPos, obstaclePrefab.transform.rotation);
    }
}
