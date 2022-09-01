using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class P2DestroyOutOfBounds : MonoBehaviour
{
    private float topBound = 30 + P2PlayerController.z;
    private float lowerBound = -10 + P2PlayerController.z;

    //public static int level = 1;
    public static int totHungry = 0;
    public static int hungry = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // if an object goes past the player view in the game remove it
        //Debug.Log(Stone.game);
        //
        if ((Stone.player1Turn && Stone.game && Stone.game2Turn) || (Stone2.player2Turn && Stone2.game && !MainMenuScript.computer && Stone2.game2Turn))
        {
            //
            totHungry = 3 + P2DetectCollisions.level  * 2;
            //
            if (transform.position.z > topBound)
            {
                Destroy(gameObject);
            }
            else if (transform.position.z < lowerBound)
            {
                hungry++;
                Destroy(gameObject);

                if (hungry == totHungry)
                {   
                    if (Stone.player1Turn)
                    {
                        Stone.gameWinner = false;
                        //Debug.Log("Winner-> " + Stone.gameWinner);
                    }
                    else if (Stone2.player2Turn)
                    {
                        Stone2.gameWinner = false;
                        //Debug.Log("Winner-> " + Stone2.gameWinner);
                    }
                    
                    hungry = 0;
                    P2DetectCollisions.feed = 0;

                    if (Stone.player1Turn)
                    {
                        Stone.game = false;
                    }
                    else if (Stone2.player2Turn)
                    {
                        Stone2.game = false;
                    }

                    //SceneManager.LoadScene("SampleScene");
                }

            }
        }
    }
}
