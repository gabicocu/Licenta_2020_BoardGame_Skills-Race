using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class P2LoseText : MonoBehaviour
{
    Text text;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
        text.text = "Hungry : 0/0"; // name of the player; 

    }

    // Update is called once per frame
    void Update()
    {
        string color = "red";
        text.text = "Hungry: " + "<color=" + color + ">" + P2DestroyOutOfBounds.hungry + "/" + P2DestroyOutOfBounds.totHungry + " </color>";

    }
}
