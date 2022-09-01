using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class P3LevelText : MonoBehaviour
{
    // Start is called before the first frame update
    Text text;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
        text.text = "Level: 0"; // name of the player; 

    }

    // Update is called once per frame
    void Update()
    {
        string color = "red";
        text.text = "Level: " + "<color=" + color + ">" + P3PlayerController.level + " </color>";

    }
}
