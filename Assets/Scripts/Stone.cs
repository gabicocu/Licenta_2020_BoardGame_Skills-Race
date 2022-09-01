using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Stone : MonoBehaviour
{
    public static bool player1Turn;

    public static bool winner = false;

    public Route currentRoute;

    public int routePosition;

    public int steps;

    public static int position;


    public static int nrCells;

    public static bool isMoving;

    public static bool movePlayer = false;

    public static int nrMoves = 0;
    //
    public static bool game = true;

    public static bool gameWinner = false;

    public static int gameRound = 0;

    public static int gameLevel = 0;

    public static int nrGames = 3; // 2

    public static bool game2Turn = false;
    //

    public static bool game3Turn = false;

    public static int gameToPlay = 0;

    //
    public static bool game4Turn = false;



    IEnumerator Move()
    {
        if(isMoving)
        {
            yield break;
        }
        isMoving = true;

        if (gameWinner)
        {
            while (steps > 0)
            {
                Vector3 nextPos = currentRoute.childNodeList[routePosition + 1].position;
                position++;

                while (MoveToNextNode(nextPos))
                {
                    yield return null;
                }

                yield return new WaitForSeconds(0.1f);
                steps--;
                //
                if (steps == 0)
                {
                    yield return new WaitForSeconds(0.5f);
                }
                //
                routePosition++;

                if (position == nrCells)
                //if (position == 20)
                {
                    DiceNumberTextScript.diceNumber = 0;
                    DiceNumberTextScript.diceNumber2 = 0;
                    DiceNumberTextScript.jump = false;
                    DiceNumberTextScript.jump2 = false;
                    DiceNumberTextScript.nrRolledDices1 = 0;
                    DiceNumberTextScript.nrRolledDices2 = 0;
                    DiceNumberTextScript.pressed = false;
                    Stone.isMoving = false;
                    Stone.movePlayer = false;
                    Stone.nrMoves = 0;
                    Stone.player1Turn = true;
                    Stone.position = 0;
                    Stone.winner = false;

                    Stone2.isMoving = false;
                    Stone2.movePlayer = false;
                    Stone2.nrMoves = 0;
                    Stone2.player2Turn = false;
                    Stone2.position = 0;
                    Stone2.winner = false;

                    game = true;
                    gameWinner = false;
                    gameRound = 0;
                    gameLevel = 0;
                    game2Turn = false;
                    Stone2.game = true;
                    Stone2.gameWinner = false;
                    Stone2.gameRound = 0;
                    Stone2.gameLevel = 0;
                    Stone2.game2Turn = false;

                    Stone2.game3Turn = false;
                    Stone2.gameToPlay = 0;
                    Stone.game3Turn = false;
                    Stone.gameToPlay = 0;

                    Stone2.game4Turn = false;
                    Stone.game4Turn = false;

                    SceneManager.LoadScene("EndGame");
                    winner = true;
                }
            }
            
        }

        isMoving = false;
        if (DiceNumberTextScript.diceNumber != DiceNumberTextScript.diceNumber2)
        {
            if (gameWinner)
            {
                gameRound++;
            }
            player1Turn = false;
            Stone2.player2Turn = true;
            Stone2.game = true;
            game = true; // redo mini game
            gameWinner = false;
        }
    }

    bool MoveToNextNode(Vector3 goal)
    {
        return goal != (transform.position = Vector3.MoveTowards(transform.position, goal, 6f * Time.deltaTime));
    }

    void Start()
    {
        player1Turn = true;
        position = 1;
        nrCells = currentRoute.childNodeList.Count;
    }

    // Update is called once per frame
    void Update()
    {
        // game to play estet mod %
        gameToPlay = gameRound % nrGames;
        if (gameToPlay == 0)
        {
            game2Turn = true;
            game3Turn = false;
            game4Turn = false;
        } else if (gameToPlay == 1)
        {
            game3Turn = true;
            game2Turn = false;
            game4Turn = false;
        }
        else if (gameToPlay == 2)
        {
            game4Turn = true;
            game3Turn = false;
            game2Turn = false;
        }

        gameLevel = gameRound / nrGames;
        if(!isMoving && nrMoves < DiceNumberTextScript.nrRolledDices1 && player1Turn)
        {
            if (!game)
            {
                steps = DiceNumberTextScript.sumDices;
                if (steps > 0) // when both dices are rolled
                {
                    //Debug.Log(steps);
                    if (routePosition + steps < currentRoute.childNodeList.Count)
                    {
                        //
                        //Time.timeScale = 0;
                        //Application.LoadLevelAdditive("Prototype 2");
                        /*if (P2DetectCollisions.win == false)
                        {
                            Application.LoadLevelAdditive("Prototype 2");
                            //SceneManager.LoadScene("Prototype 2");
                        } else if (P2DetectCollisions.win)
                        {
                            Debug.Log("Am ajuns aicisa");
                            //
                            StartCoroutine(Move());
                        }
                        */

                        StartCoroutine(Move());

                    }
                    else
                    {
                        //Debug.Log("Number too high");
                        //
                        //Time.timeScale = 0;


                        //SceneManager.LoadScene("Prototype 2");
                        //Time.timeScale = 0;

                        //Application.LoadLevelAdditive("Prototype 2");
                        //

                        steps = currentRoute.childNodeList.Count - routePosition;
                        StartCoroutine(Move());
                    }

                    nrMoves++;
                }
            }
        }
    }
}
