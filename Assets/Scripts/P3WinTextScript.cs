using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class P3WinTextScript : MonoBehaviour
{
    Text text;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
        text.text = "Jumped : 0/0"; // name of the player; 

    }

    // Update is called once per frame
    void Update()
    {
        string color = "orange";
        text.text = "Jumped: " + "<color=" + color + ">" + P3PlayerController.jumped + "/" + P3PlayerController.totJumped + " </color>";

    }
}
