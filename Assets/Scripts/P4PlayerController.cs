using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P4PlayerController : MonoBehaviour
{
    private float forwardInput;
    private Rigidbody playerRb;
    public float speed = 2f;
    private float powerupStrength = 50.0f;
    private GameObject focalPoint;
    public bool hasPowerup = false;
    public GameObject powerupIndicator;
    public static int lives = 0;
    public static int defeated = 0;
    public static int totLives;
    public static int goneLives = 0;
    public static int totDefeated;
    public static int level = 0; // to change in 0
    public static bool inWork = false;

    public static Camera game4Cam;
    public static float x, y, z;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal Point");

        game4Cam = GameObject.Find("Game4Camera").GetComponent<Camera>();
        x = game4Cam.transform.position.x;
        y = game4Cam.transform.position.y - 9.88f;
        z = game4Cam.transform.position.z + 20f;
        //Debug.Log(game3Cam.transform.position + " " + this.transform.position);

        transform.position = new Vector3(x, y, z);
    }

    // Update is called once per frame
    void Update()
    {

            Debug.Log(transform.position);
        if ((Stone.player1Turn && Stone.game && Stone.game4Turn) || (Stone2.player2Turn && Stone2.game && !MainMenuScript.computer && Stone2.game4Turn))
        {
            if (Stone.player1Turn)
            {
                level = Stone.gameLevel;
            }
            else if (Stone2.player2Turn)
            {
                level = Stone2.gameLevel; // Stone2
            }

            totDefeated = level + 1;
            //Debug.Log(x + " " + y + " " + z);
            //Debug.Log(transform.position);
            if (transform.position.y < (y - 2f)) // if dies
            {
                transform.position = new Vector3(x, (y - 1.21f), z);
                Debug.Log("Dead");
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
                defeated = 0;

                if (Stone.player1Turn)
                {
                    Stone.game = false;
                }
                else if (Stone2.player2Turn)
                {
                    Stone2.game = false;
                }

            }

            forwardInput = Input.GetAxis("Vertical");
            /*
            float forwardInput = 0;
            if (Input.GetKey(KeyCode.UpArrow))
            {
                forwardInput = 0.5f;
            } else if (Input.GetKey(KeyCode.DownArrow)) {
                forwardInput = -0.5f;
            }
            */

            playerRb.AddForce(focalPoint.transform.forward * forwardInput * speed);
            //transform.Translate(Vector3.right * forwardInput * Time.deltaTime * speed);


            //Debug.Log("Inside" + transform.position);
            powerupIndicator.transform.position = transform.position + new Vector3(0, -0.5f, 0);
        } else if (transform.position.y < (y - 2f)) // if dies
        {
            transform.position = new Vector3(x, (y - 1.21f), z);
        } else
        {
            transform.position = new Vector3(x, transform.position.y, z);
        }


    }

    private void OnTriggerEnter(Collider other)
    {
        if ((Stone.player1Turn && Stone.game && Stone.game4Turn) || (Stone2.player2Turn && Stone2.game && !MainMenuScript.computer && Stone2.game4Turn))
        {
            if (other.CompareTag("Powerup"))
            {
                hasPowerup = true;
                powerupIndicator.gameObject.SetActive(true);
                Destroy(other.gameObject);
                StartCoroutine(PowerupCountdownRoutine());
            }
        }
    }

    IEnumerator PowerupCountdownRoutine()
    {
        if ((Stone.player1Turn && Stone.game && Stone.game4Turn) || (Stone2.player2Turn && Stone2.game && !MainMenuScript.computer && Stone2.game4Turn))
        {
            yield return new WaitForSeconds(10);
            hasPowerup = false;
            powerupIndicator.gameObject.SetActive(false);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if ((Stone.player1Turn && Stone.game && Stone.game4Turn) || (Stone2.player2Turn && Stone2.game && !MainMenuScript.computer && Stone2.game4Turn))
        {
            if (collision.gameObject.CompareTag("Enemy") && hasPowerup)
            {
                Rigidbody enemyRb = collision.gameObject.GetComponent<Rigidbody>();
                Vector3 awayFromPlayer = collision.gameObject.transform.position - transform.position;

                enemyRb.AddForce(awayFromPlayer * powerupStrength, ForceMode.Impulse);
                //Debug.Log("Collided with: " + collision.gameObject.name + " with powerup set to " + hasPowerup);
            }
        }
    }
}
