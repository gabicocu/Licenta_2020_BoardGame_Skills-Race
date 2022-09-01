using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class P2NameTextScript : MonoBehaviour
{
    Text text;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
        text.text = "Player Name"; // name of the player; 

    }

    // Update is called once per frame
    void Update()
    {
        //if (Stone.player1Turn)
        //*//
        if (Stone.player1Turn)
        {
            string color = MainMenuScript.color1Name;
            text.text = "<color=" + MainMenuScript.color1Name + ">" + MainMenuScript.player1Name + " </color>";
        }
        else if (Stone2.player2Turn)
        {
            string color = MainMenuScript.color2Name;
            text.text = "<color=" + MainMenuScript.color2Name + ">" + MainMenuScript.player2Name + " </color>";
        }
    }
}
