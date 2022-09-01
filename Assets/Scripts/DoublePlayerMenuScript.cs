using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class DoublePlayerMenuScript : MonoBehaviour
{
    public TMP_InputField player1NameField;
    public TMP_InputField player2NameField;
    public TMP_InputField color1Field;
    public TMP_InputField color2Field;
    public static bool computer;
    void Start()
    {

    }

    // Update is called once per frame
    public void GetNames()
    {
        MainMenuScript.player1Name = player1NameField.text;
        MainMenuScript.color1Name = color1Field.text;
        MainMenuScript.player2Name = player2NameField.text;
        MainMenuScript.color2Name = color2Field.text;
        MainMenuScript.computer = false;


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

        Stone.game = true;
        Stone.gameWinner = false;
        Stone.gameRound = 0;
        Stone.gameLevel = 0;
        Stone.game2Turn = false;
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


        //Debug.Log(MainMenuScript.player1Name);
    }
}
