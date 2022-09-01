using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceCheckZoneScript : MonoBehaviour {

	Vector3 diceVelocity;
	Vector3 diceVelocity2;

	// Update is called once per frame
	void FixedUpdate () {
		diceVelocity = DiceScript.diceVelocity;
		diceVelocity2 = DiceScript2.diceVelocity;
	}

	void OnTriggerStay(Collider col)
	{
		if (diceVelocity.x == 0f && diceVelocity.y == 0f && diceVelocity.z == 0f &&
						  diceVelocity2.x == 0f && diceVelocity2.y == 0f && diceVelocity2.z == 0f)
		{
			//DiceNumberTextScript.diceNumber = 0;
			//Debug.Log(col.collider.name);
			/*
			if (col.gameObject.tag == "dice1")
				Debug.Log("da");
			else if (col.gameObject.tag == "dice2")
				Debug.Log("nu");
			*/
			//Debug.Log(col.gameObject.transform.parent.gameObject.name);
			//Debug.Log(col.gameObject.tag);
			if (col.gameObject.transform.parent.gameObject.name == "Dice")
			{
				switch (col.gameObject.name)
				{
					case "Side1":
						DiceNumberTextScript.diceNumber = 6;
						break;
					case "Side2":
						DiceNumberTextScript.diceNumber = 5;
						break;
					case "Side3":
						DiceNumberTextScript.diceNumber = 4;
						break;
					case "Side4":
						DiceNumberTextScript.diceNumber = 3;
						break;
					case "Side5":
						DiceNumberTextScript.diceNumber = 2;
						break;
					case "Side6":
						DiceNumberTextScript.diceNumber = 1;
						break;
				}
					DiceNumberTextScript.jump = false;
				

				//
				//Stone.movePlayer = true;
				//
			}

			if (col.gameObject.transform.parent.gameObject.name == "Dice2")
			{
				switch (col.gameObject.name)
				{
					case "Side1":
						DiceNumberTextScript.diceNumber2 = 6;
						break;
					case "Side2":
						DiceNumberTextScript.diceNumber2 = 5;
						break;
					case "Side3":
						DiceNumberTextScript.diceNumber2 = 4;
						break;
					case "Side4":
						DiceNumberTextScript.diceNumber2 = 3;
						break;
					case "Side5":
						DiceNumberTextScript.diceNumber2 = 2;
						break;
					case "Side6":
						DiceNumberTextScript.diceNumber2 = 1;
						break;
				}
					DiceNumberTextScript.jump2 = false;
				

				//
				//Stone.movePlayer = true;
				//
				
				
			}
			


		}
	}
}
