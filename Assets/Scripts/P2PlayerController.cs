using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P2PlayerController : MonoBehaviour
{
    public static Camera game2Cam;
    public static float x, y, z;
    private float horizontalInput;
    private float speed = 25.0f;
    private float xRange = 20.0f;

    

    public GameObject projectilePrefab;

    // Start is called before the first frame update
    void Start()
    {
        game2Cam = GameObject.Find("Game2Camera").GetComponent<Camera>();
        x = game2Cam.transform.position.x;
        y = game2Cam.transform.position.y - 25;
        z = game2Cam.transform.position.z - 7.5f;
        //Debug.Log(game2Cam.transform.position);
        transform.position = new Vector3(x, y, z);
    }

    // Update is called once per frame
    void Update()
    {
        if ((Stone.player1Turn && Stone.game && Stone.game2Turn) || (Stone2.player2Turn && Stone2.game && Stone2.game2Turn && !MainMenuScript.computer))
        {
            if (transform.position.x < (-xRange + x))
            {
                transform.position = new Vector3(-xRange + x, transform.position.y, transform.position.z);
            }

            if (transform.position.x > (xRange + x))
            {
                transform.position = new Vector3(xRange + x, transform.position.y, transform.position.z);
            }

            horizontalInput = Input.GetAxis("Horizontal");
            transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);

            if (Input.GetKeyDown(KeyCode.F))
            {
                // Launch a projectile from the player
                Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
            }
        }
    }
}
