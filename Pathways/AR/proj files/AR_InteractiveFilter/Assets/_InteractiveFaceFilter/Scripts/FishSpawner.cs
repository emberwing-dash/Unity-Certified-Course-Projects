using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishSpawner : MonoBehaviour
{
    [SerializeField] GameObject fish1;

    public float timeInterval = 0f;

    void Update()
    {
        timeInterval += Time.deltaTime;

        if (timeInterval >= 2f)
        {
            int randNum = Random.Range(0, 2); // 0 or 1

            Instantiate(fish1, transform.position, transform.rotation);

            timeInterval = 0f;
        }
    }
}
