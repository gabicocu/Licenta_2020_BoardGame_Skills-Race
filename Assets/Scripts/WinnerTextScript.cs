using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class WinnerTextScript : MonoBehaviour
{
    // Start is called before the first frame update
    Text text;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
        /////////////
        text.text = "Player Name"; // name of the player; 
        /////////////
        //text.transform.position = new Vector3(100, 420, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Stone.winner)
        {
            //text.text = "PLAYER 1";
            string color = MainMenuScript.color1Name;
            text.text = "<color=" + MainMenuScript.color1Name + ">" + MainMenuScript.player1Name + " </color>";
        }
        else if (Stone2.winner)
        {
            string color = MainMenuScript.color2Name;
            text.text = "<color=" + MainMenuScript.color2Name + ">" + MainMenuScript.player2Name + " </color>";
        }
        //text.text = "Player";
    }
}
