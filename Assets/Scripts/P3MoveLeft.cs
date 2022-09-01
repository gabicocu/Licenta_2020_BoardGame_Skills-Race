using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P3MoveLeft : MonoBehaviour
{

    private float speed = 30;
    private P3PlayerController playerControllerScript;
    private float leftBound = -15;
    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<P3PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if ((Stone.player1Turn && Stone.game && Stone.game3Turn) || (Stone2.player2Turn && Stone2.game && !MainMenuScript.computer && Stone2.game3Turn))
        {

            speed = 40f + P3PlayerController.level * 5;
            //if (playerControllerScript.gameOver == false)
            {
                transform.Translate(Vector3.left * Time.deltaTime * speed);
            }

            if (transform.position.x < (leftBound + P3PlayerController.x) && gameObject.CompareTag("Obstacle"))
            {
                P3PlayerController.jumped++;
                Destroy(gameObject);

                if (P3PlayerController.jumped == P3PlayerController.totJumped)
                {
                    if (Stone.player1Turn)
                    {
                        Stone.gameWinner = true;
                        //Debug.Log("Winner-> " + Stone.gameWinner);
                    }
                    else if (Stone2.player2Turn)
                    {
                        Stone2.gameWinner = true;
                        //Debug.Log("Winner-> " + Stone2.gameWinner);
                    }

                    P3PlayerController.jumped = 0;
                    P3PlayerController.destroyed = 0;
                    P3PlayerController.isOnGround = true;

                    if (Stone.player1Turn)
                    {
                        Stone.game = false;
                    }
                    else if (Stone2.player2Turn)
                    {
                        Stone2.game = false;
                    }
                }
            }
        }

    }
}
