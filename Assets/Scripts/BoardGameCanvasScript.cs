using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BoardGameCanvasScript : MonoBehaviour
{
    public Canvas boardCanvas;
    // Start is called before the first frame update
    void Start()
    {
        //GameObject tempObject = GameObject.Find("Canvas");
        boardCanvas = boardCanvas.GetComponent<Canvas>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if ((Stone.player1Turn && Stone.game) || (Stone2.player2Turn && Stone2.game && !MainMenuScript.computer)) {
            boardCanvas.enabled = false;
        } else
        {
            boardCanvas.enabled = true;
        }
        
    }
}
