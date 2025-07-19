using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;

    float fireRate = 1;
    public float nextRate = 0;

    // Update is called once per frame
    void Update()
    {
        // On spacebar press, send dog
        if (Input.GetKeyDown(KeyCode.Space) && Time.time>nextRate)
        {
            nextRate = Time.time + fireRate;
            spawnDog();
        }
    }

    void spawnDog()
    {
        Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
    }
}
