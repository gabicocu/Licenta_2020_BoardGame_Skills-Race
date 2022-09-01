using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PositionTextScript : MonoBehaviour
{
    Text text;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
        text.text = "POSITION: ";
        //text.transform.position = new Vector3(100, 380, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Stone.player1Turn)
        {
            text.text = "POSITION: " + Stone.position + "/" + Stone.nrCells;
        } else if (Stone2.player2Turn)
        {
            text.text = "POSITION: " + Stone2.position + "/" + Stone2.nrCells;
        }
    }
}
