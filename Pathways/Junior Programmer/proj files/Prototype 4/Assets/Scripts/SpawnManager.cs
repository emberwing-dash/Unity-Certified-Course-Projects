using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemyPrefab;
    public GameObject powerupPrefab;
    private int index;

    public float spawnRange = 9;
    public int enemyCount;

    public int waveNumber = 1;
    void Start()
    {
        index = enemyPrefab.Length;
        spawnEnemyWaves(waveNumber);
        Instantiate(powerupPrefab, GenerateSpawnPos(), powerupPrefab.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsByType<Enemy>(FindObjectsSortMode.None).Length;
        if (enemyCount == 0)
        {
            waveNumber++;
            spawnEnemyWaves(waveNumber);

            Instantiate(powerupPrefab, GenerateSpawnPos(), powerupPrefab.transform.rotation);
        }
    }

    Vector3 GenerateSpawnPos()
    {
        float spawnX = Random.Range(-spawnRange, spawnRange);
        float spawnZ = Random.Range(-spawnRange, spawnRange);

        return new Vector3(spawnX, 0, spawnZ);
    }

    void spawnEnemy()
    {
        for (int i = 0; i < index; i++)
        {
            Instantiate(enemyPrefab[i], GenerateSpawnPos(), enemyPrefab[i].transform.rotation);
        }
    }

    void spawnEnemyWaves(int n)
    {
        for (int i = 0; i < n; i++)
        {
            spawnEnemy();
        }
    }
}
