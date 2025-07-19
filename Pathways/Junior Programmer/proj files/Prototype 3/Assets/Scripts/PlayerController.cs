using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private Rigidbody Pb;
    private Animator playerAnim;

    public float jumpForce = 10f;
    public float gravityModifier;

    private bool isGrounded;
    public bool gameOver;

    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;

    public AudioClip jumpSound;
    public AudioClip crashSound;
    private AudioSource playerAudio;

    void Start()
    {
        Pb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;

        playerAnim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded && !gameOver)
        {
            Pb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
            playerAnim.SetTrigger("Jump_trig");

            dirtParticle.Stop();
            playerAudio.PlayOneShot(jumpSound, 1.0f);
            
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            dirtParticle.Play();
        }

        if (collision.gameObject.CompareTag("Obstacle"))
        {
            gameOver = true;
            Debug.Log("Game Over");

            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);

            explosionParticle.Play();
            dirtParticle.Stop();
            playerAudio.PlayOneShot(crashSound, 1.0f);
        }
            
    }
}
