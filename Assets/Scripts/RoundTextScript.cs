using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class RoundTextScript : MonoBehaviour
{

    Text text;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
        text.text = "ROUND: ";
        //text.transform.position = new Vector3(780, 420, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Stone.player1Turn)
        {
            //text.text = "DICES: " + "<color=" + color + ">" + diceNumber2.ToString() + " " + diceNumber.ToString() + "</color>" + "; SUM: " + sumDices.ToString();
            text.text = "ROUND: " + Stone.nrMoves;
        } else if (Stone2.player2Turn)
        {
            text.text = "ROUND: " + Stone2.nrMoves;
        }
    }
}
