using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Game3CanvasScript : MonoBehaviour
{
    public Canvas game3Canvas;
    void Start()
    {
        //GameObject tempObject = GameObject.Find("Canvas");
        game3Canvas = game3Canvas.GetComponent<Canvas>();
        game3Canvas.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if ((Stone.player1Turn && Stone.game) || (Stone2.player2Turn && Stone2.game && !MainMenuScript.computer))
        {
            if ((Stone.player1Turn && Stone.game3Turn) || (Stone2.player2Turn && Stone2.game3Turn && !MainMenuScript.computer))
            {
                game3Canvas.enabled = true;
            }
            
        } else
        {
            game3Canvas.enabled = false;
        }
    }
}
