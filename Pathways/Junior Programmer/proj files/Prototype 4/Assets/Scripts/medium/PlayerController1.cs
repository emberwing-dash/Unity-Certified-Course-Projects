using System.Collections;
using UnityEngine;
using static PowerUp;

public class PlayerController1 : MonoBehaviour
{
    public PowerUpType currentPowerUp = PowerUpType.None;
    public GameObject rocketPrefab;
    private GameObject tmpRocket;
    private Coroutine powerupCountdown;

    Rigidbody rb;
    float speed = 1.4f;

    public bool hasPowerup;
    private float powerupStrength = 15f;

    private GameObject focalPoint;
    public GameObject indicator;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal Point");
    }

    // Update is called once per frame
    void Update()
    {
        indicator.transform.position = transform.position + new Vector3(0, -0.5f, 0);

        float input = Input.GetAxis("Vertical");
        rb.AddForce(focalPoint.transform.forward * input * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        

        if (other.CompareTag("Powerup"))
        {
            hasPowerup = true;
            currentPowerUp = other.gameObject.GetComponent<PowerUp>().powerUpType;
            indicator.gameObject.SetActive(true);
            Destroy(other.gameObject);
            if (powerupCountdown != null)
            {
                StopCoroutine(powerupCountdown);
            }
            powerupCountdown = StartCoroutine(PowerupCountdownRoutine());
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy") && hasPowerup)
        {
            Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = (collision.gameObject.transform.position - transform.position);

            Debug.Log("Collided with " + collision.gameObject.name + " with powerup set to " + hasPowerup);
            rb.AddForce(awayFromPlayer * powerupStrength, ForceMode.Impulse);

        }
    }

    IEnumerator PowerupCountdownRoutine()
    {
        //Set powerup to false after 7 secs
        yield return new WaitForSeconds(7);
        hasPowerup = false;
        indicator.SetActive(false); 
    }
}
