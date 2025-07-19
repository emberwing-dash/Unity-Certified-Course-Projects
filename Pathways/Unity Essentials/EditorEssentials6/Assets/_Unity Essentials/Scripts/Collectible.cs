using UnityEngine;

public class Collectible : MonoBehaviour
{
    public float rotationSpeed;
    public GameObject onColletEffect;
    void Start()
    {
        
    }



    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, rotationSpeed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Instantiate(onColletEffect, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
