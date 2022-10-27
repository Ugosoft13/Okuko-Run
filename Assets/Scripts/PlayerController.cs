using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    private Rigidbody playerRb;
    public float boundary =  2.78f;
    public float jumpForce;
    public float gravityModifier;
    public bool isOnGround = true;
    public ParticleSystem dirtParticle;
    public ParticleSystem explosionParticle;
    public Animator chickenAnim;
    public int coinCount;

    public GameObject bigChick;
    public GameObject smallChick;

    public bool gameOver = false;
    public AudioClip coinSound;
    public AudioClip crashSound;
    public AudioClip jumpSound;
    public AudioClip powerupSound;
    private AudioSource playerAudio;

    private SwipeManager swipeManager;
 //   private int desiredLane = 1;//0:left, 1:middle, 2:right
   // public float laneDistance = 2.5f;//The distance between tow lanes

    public bool chickActive = false;


    // Start is called before the first frame update
    void Start()
    {
        playerAudio = GetComponent<AudioSource>();

        transform.position = new Vector3(0, 0.3f, -0.02f);
        playerRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;

       
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOver == true)
        {
            chickenAnim.enabled = false;
          //  gameObject.GetComponent<AudioSource>().enabled = false;
           // fadeAnimationScript.StartFading();

           // gameObject.GetComponent<Animator>().enabled = false;
        }
     
        MovePlayer();

        Boundary();

        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && gameOver !=true)
        {
            dirtParticle.Stop();
            playerAudio.PlayOneShot(jumpSound, 1.0f);
            
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;

        }
        MovePlayer();

        Boundary();

    }

    //Moves player
    void MovePlayer()
    {
       // if (gameOver != true)
        //{
          //  float horizontalInput = Input.GetAxis("Horizontal");
            //float verticalInput = Input.GetAxis("Vertical");

//            playerRb.AddForce(Vector3.forward * speed * verticalInput);
  //          playerRb.AddForce(Vector3.right * speed * horizontalInput);
    //    }

       
    }

    // Boundaries: keeps player in bounds
    void Boundary()
    {
        if (transform.position.x < -boundary)
        {
            transform.position = new Vector3(-boundary, transform.position.y, transform.position.z);
        }
        if (transform.position.x > boundary)
        {
            transform.position = new Vector3(boundary, transform.position.y, transform.position.z);
        }
        if (transform.position.z < -0.85f)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -0.85f);
        }
        if (transform.position.z > 4.02f)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, 4.02f);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        
            if (collision.gameObject.CompareTag("Ground") && gameOver!=true)
            {
                isOnGround = true;
                dirtParticle.Play();
            }

            else if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Animal"))
            {

                explosionParticle.Play();
                Debug.Log("Collison with enemy");
                dirtParticle.Stop();
                playerAudio.PlayOneShot(crashSound, 1.0f);

                explosionParticle.Play();
                gameOver = true;

            }
        

       
       
    }

    private void OnTriggerEnter (Collider other)
    {
        if(other.gameObject.CompareTag("Powerup"))
        {
            Destroy(other.gameObject);
            Debug.Log("Powerup Collected");
            playerAudio.PlayOneShot(powerupSound, 1.0f);
            bigChick.SetActive(false);
            smallChick.transform.position = new Vector3(smallChick.transform.position.x, -0.24f, smallChick.transform.position.z);
            smallChick.SetActive(true);
            chickActive = true;
            StartCoroutine(PowerupCountdownRoutine());
        }

        if (other.gameObject.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
            Debug.Log("Coin Collected");
            playerAudio.PlayOneShot(coinSound, 1.0f);
            coinCount++;
        }

        IEnumerator PowerupCountdownRoutine()
        {
            yield return new WaitForSeconds(10);
            smallChick.SetActive(false);
            chickActive = false;
            bigChick.transform.position = new Vector3(bigChick.transform.position.x, -0.33f, bigChick.transform.position.z);
            bigChick.SetActive(true);

        }
    }
}
