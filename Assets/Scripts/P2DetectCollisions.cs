using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class P2DetectCollisions : MonoBehaviour
{

    public static int level = 0;
    public static int totFed;
    public static int feed = 0;

    public static bool win = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
       if ((Stone.player1Turn && Stone.game && Stone.game2Turn) || (Stone2.player2Turn && Stone2.game && !MainMenuScript.computer && Stone2.game2Turn)) /// Stone2
        {
            if (Stone.player1Turn)
            {
                level = Stone.gameLevel;
            } else if (Stone2.player2Turn)
            {
                level = Stone2.gameLevel; // Stone2
            }
            totFed = 10 + level * 5;
        }
         
    }

    private void OnTriggerEnter(Collider other)
    {
        //Stone2.game2Turn in capat!!
        if ((Stone.player1Turn && Stone.game && Stone.game2Turn) || (Stone2.player2Turn && Stone2.game && !MainMenuScript.computer && Stone2.game2Turn))
        {
            feed++;
            //Debug.Log("feed: " + feed / 2);
            Destroy(gameObject);
            Destroy(other.gameObject);

            if ((feed / 2) == totFed)
            {
                //win = true;
                if (Stone.player1Turn)
                {
                    Stone.gameWinner = true;
                    //Debug.Log("Winner :" + Stone.gameWinner);
                }
                else if (Stone2.player2Turn)
                {
                    Stone2.gameWinner = true;
                    //Debug.Log("Winner :" + Stone2.gameWinner);
                }

               
                feed = 0;
                P2DestroyOutOfBounds.hungry = 0;

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
