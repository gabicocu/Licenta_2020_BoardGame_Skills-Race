using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game2CanvasScript : MonoBehaviour
{
    public Canvas game2Canvas;
    void Start()
    {
        //GameObject tempObject = GameObject.Find("Canvas");
        game2Canvas = game2Canvas.GetComponent<Canvas>();
        game2Canvas.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if ((Stone.player1Turn && Stone.game) || (Stone2.player2Turn && Stone2.game && !MainMenuScript.computer))
        {
            if ((Stone.player1Turn && Stone.game2Turn) || (Stone2.player2Turn && Stone2.game2Turn && !MainMenuScript.computer))
            {
                game2Canvas.enabled = true;
            }
        } else
        {
            game2Canvas.enabled = false;
        }
    }
}
