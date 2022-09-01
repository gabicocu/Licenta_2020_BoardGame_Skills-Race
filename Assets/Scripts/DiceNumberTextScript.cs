using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiceNumberTextScript : MonoBehaviour {

	Text text;
	public static int diceNumber;
	public static int diceNumber2;
	public static int sumDices;
	public static bool jump = false;
	public static bool jump2 = false;
	public static bool pressed = false;

	
	public static int nrRolledDices1 = 0;
	//
	public static int nrRolledDices2 = 0;
	//

	// Use this for initialization
	void Start () {
		text = GetComponent<Text> ();
		text.text = "Good Luck!";
		//diceNumber += diceNumber2;
	}
	
	// Update is called once per frame
	void Update () {
		if (pressed) // make the sum only after the dices are rolled
		{
			//text.transform.position = new Vector3(400, 420, 0);
			//
			string color = "red";

			//color = MainMenuScript.color1Name;
			//

			if (jump == false && jump2 == false) // daca aman2 s au oprit
			{
				sumDices = diceNumber + diceNumber2;
				text.text = "DICES: " + "<color=" + color + ">" + diceNumber2.ToString() + " " + diceNumber.ToString() + "</color>"
					+ "; SUM: " + "<color=" + color + ">" + sumDices.ToString() + "</color>";
				//text.text = "DICES: " + "<color=red>" + diceNumber2.ToString() +  " " + diceNumber.ToString() + "</color>" + "; SUM: " + sumDices;
			}
			else // show 0 as sum( the dices are still rolling)
			{
				text.text = "DICES: " + "<color=" + color + ">" + diceNumber2.ToString() + " " + diceNumber.ToString() + "</color>"
					+ "; SUM: " + "<color=" + color + ">" + sumDices.ToString() + "</color>";
				//text.text = "DICES: " + "<color=red>" + diceNumber2.ToString() + " " + diceNumber.ToString() + "</color>" + "; SUM: 0";
			}
		}
	}
}
