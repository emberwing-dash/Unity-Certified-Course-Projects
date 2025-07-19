using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animalPrefabs;

    public int animalIndex;
    private Vector3 randPos;

    private float delay = 1.5f;
    private float spawnInterval = 2;
    void Start()
    {
        InvokeRepeating("SpawnRandomAnimal", spawnInterval, delay);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnRandomAnimal()
    {
        animalIndex = Random.Range(0, animalPrefabs.Length);
        randPos = new Vector3(Random.Range(-20, 20), 0, 20);

        Instantiate(animalPrefabs[animalIndex], randPos,
            animalPrefabs[animalIndex].transform.rotation);
    }
}
