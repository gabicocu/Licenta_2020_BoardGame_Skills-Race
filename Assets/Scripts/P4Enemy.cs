using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P4Enemy : MonoBehaviour
{
    public float speed = 0.1f;
    private Rigidbody enemyRb;
    private GameObject player;
    private float fallPosition = -10.0f;

    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("PlayerP4");
    }

    // Update is called once per frame
    void Update()
    {
        if ((Stone.player1Turn && Stone.game && Stone.game4Turn) || (Stone2.player2Turn && Stone2.game && !MainMenuScript.computer && Stone2.game4Turn))
        {
            Vector3 lookDirection = (player.transform.position - transform.position).normalized;
            enemyRb.AddForce(lookDirection * speed);
            if (transform.position.y < (fallPosition + P4PlayerController.y))
            {
                P4PlayerController.defeated++;
                Destroy(gameObject);
                //Debug.Log("Defeated : " + P3PlayerController.defeated);
                if (P4PlayerController.defeated == P4PlayerController.totDefeated)
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

                    Debug.Log("Game Won" + P4PlayerController.defeated);
                    P4PlayerController.defeated = 0;

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
