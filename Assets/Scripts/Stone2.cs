using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Stone2 : MonoBehaviour
{
    public static bool player2Turn;

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

    public static int nrGames = 3;

    public static bool game2Turn = false;
    //

    public static bool game3Turn = false;

    public static int gameToPlay = 0;

    public static bool game4Turn = false;

    IEnumerator Move()
    {
        if (isMoving)
        {
            yield break;
        }
        isMoving = true;
        int lucky = Random.Range(0, 2);
        if ((MainMenuScript.computer && lucky == 1) || (gameWinner))
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
                    Stone.game = true;
                    Stone.gameWinner = false;
                    Stone.gameRound = 0;
                    Stone.gameLevel = 0;
                    Stone.game2Turn = false;

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
            if (!MainMenuScript.computer && gameWinner)
            {
                gameRound++;
            }
            player2Turn = false;
            Stone.player1Turn = true;
            if (!MainMenuScript.computer)
            {
                Stone.game = true;
                game = true;
                gameWinner = false;
            }
        }
    }

    bool MoveToNextNode(Vector3 goal)
    {
        return goal != (transform.position = Vector3.MoveTowards(transform.position, goal, 6f * Time.deltaTime));
    }

    void Start()
    {
        player2Turn = false;
        position = 1;
        nrCells = currentRoute.childNodeList.Count;
    }

    // Update is called once per frame
    void Update()
    {
        if (!MainMenuScript.computer)
        {
            gameToPlay = gameRound % nrGames;
            if (gameToPlay == 0)
            {
                game2Turn = true;
                game3Turn = false;
                game4Turn = false;
            }
            else if (gameToPlay == 1)
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
        
        }
        if (!isMoving && nrMoves < DiceNumberTextScript.nrRolledDices2 && player2Turn)
        {
            if (MainMenuScript.computer || !game)
            {

                steps = DiceNumberTextScript.sumDices;
                if (steps > 0) // when both dices are rolled
                {
                    //Debug.Log(steps);
                    if (routePosition + steps < currentRoute.childNodeList.Count)
                    {
                        StartCoroutine(Move());
                    }
                    else
                    {
                        //Debug.Log("Number too high");
                        steps = currentRoute.childNodeList.Count - routePosition;
                        StartCoroutine(Move());
                    }

                    nrMoves++;
                    //player2Turn = false;     // it will change them immediately(doesn't waot for the coroutine to end
                    //Stone.player1Turn = true;
                }
            }
        }
    }
}
