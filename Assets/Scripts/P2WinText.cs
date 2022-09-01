using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class P2WinText : MonoBehaviour
{
    Text text;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
        text.text = "Fed : 0/0"; // name of the player; 

    }

    // Update is called once per frame
    void Update()
    {
        string color = "orange";
        text.text = "Fed: " + "<color=" + color + ">" + (P2DetectCollisions.feed / 2) + "/" + P2DetectCollisions.totFed + " </color>";

    }
}
