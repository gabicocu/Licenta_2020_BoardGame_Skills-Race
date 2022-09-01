using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P3PlayerController : MonoBehaviour
{
    public static Camera game3Cam;
    public static float x, y, z;
    private Rigidbody playerRb;
    private Animator playerAnim;
    private AudioSource playerAudio;

    //public ParticleSystem explosionParticle;
    //public ParticleSystem dirtParticle;
    public AudioClip jumpSound;
    public AudioClip crashSound;
    public float jumpForce = 10;
    public float gravityModifier;
    public static bool isOnGround = true;
    // Start is called before the first frame update

    public static int destroyed = 0;
    public static int jumped = 0;
    public static int totDestroyed;
    public static int totJumped;
    public static int level = 0;
    void Start()
    {
        totJumped = 5 + 5 * level;
        totDestroyed = 2 + 2 * level;
        playerRb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
        Physics.gravity *= gravityModifier;

        game3Cam = GameObject.Find("Game3Camera").GetComponent<Camera>();
        x = game3Cam.transform.position.x - 8;
        y = game3Cam.transform.position.y - 4;
        z = game3Cam.transform.position.z + 15f;
        //Debug.Log(game3Cam.transform.position + " " + this.transform.position);

        transform.position = new Vector3(x, y, z);


    }

    // Update is called once per frame
    void Update()
    {
        if ((Stone.player1Turn && Stone.game && Stone.game3Turn) || (Stone2.player2Turn && Stone2.game && !MainMenuScript.computer && Stone2.game3Turn))
        {
            if (Stone.player1Turn)
            {
                level = Stone.gameLevel;
            }
            else if (Stone2.player2Turn)
            {
                level = Stone2.gameLevel; // Stone2
            }

            totJumped = 5 + 5 * level;
            totDestroyed = 2 + level;

            // Debug.Log(game3Cam.transform.position);
            if (Input.GetKeyDown(KeyCode.J) && isOnGround)
            {
                playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                isOnGround = false;
                playerAnim.SetTrigger("Jump_trig");
                playerAudio.PlayOneShot(jumpSound, 1.0f);
            }

            //Debug.Log("Destroyed : " + destroyed);
           // Debug.Log("Jumped : " + jumped);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if ((Stone.player1Turn && Stone.game && Stone.game3Turn) || (Stone2.player2Turn && Stone2.game && !MainMenuScript.computer && Stone2.game3Turn))
        {
            if (collision.gameObject.CompareTag("Ground"))
            {
                isOnGround = true;
            }
            else if (collision.gameObject.CompareTag("Obstacle"))
            {
                destroyed++;
                Destroy(collision.gameObject);

                if (destroyed == totDestroyed)
                {
                    if (Stone.player1Turn)
                    {
                        Stone.gameWinner = false;
                        //Debug.Log("Winner :" + Stone.gameWinner);
                    }
                    else if (Stone2.player2Turn)
                    {
                        Stone2.gameWinner = false;
                        //Debug.Log("Winner :" + Stone2.gameWinner);
                    }
                    destroyed = 0;
                    jumped = 0;
                    isOnGround = true;

                    if (Stone.player1Turn)
                    {
                        Stone.game = false;
                    }
                    else if (Stone2.player2Turn)
                    {
                        Stone2.game = false;
                    }

                }
                
                //Debug.Log("Game Over");
                /*
                playerAnim.SetBool("Death_b", true);
                playerAnim.SetInteger("DeathType_int", 1);
                playerAudio.PlayOneShot(crashSound, 1.0f);
                */
            }
        }
    }
}
