using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceScript : MonoBehaviour {

	static Rigidbody rb;
	public static Vector3 diceVelocity;
	static Camera diceCam;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		diceCam = GameObject.Find("DiceCamera").GetComponent<Camera>();
	}
	
	// Update is called once per frame
	public void Update () {
		diceVelocity = rb.velocity;
		// MainMenuScript.computer == true
		if(Stone2.player2Turn && MainMenuScript.computer && DiceNumberTextScript.jump == false && Stone.isMoving == false && Stone2.isMoving == false && DiceNumberTextScript.nrRolledDices2 == Stone2.nrMoves)
        {
			DiceNumberTextScript.jump = true;
			DiceNumberTextScript.diceNumber = 0;
			float dirX = Random.Range(0, 800);
			float dirY = Random.Range(0, 800);
			float dirZ = Random.Range(0, 800);

			float x = diceCam.transform.position.x + 0.1f + 7;
			float y = diceCam.transform.position.y + 2 - 6;
			float z = diceCam.transform.position.z - 0.5f;

			//Debug.Log(diceCam.transform.position);
			transform.position = new Vector3(x, y, z);
			transform.rotation = Quaternion.identity;
			rb.AddForce(transform.up * 550);
			rb.AddTorque(dirX, dirY, dirZ);
			
			//

			DiceNumberTextScript.nrRolledDices2++;
			//Debug.Log(DiceNumberTextScript.nrRolledDices2);
			
		} else if (((Stone.player1Turn && !Stone.game) || (Stone2.player2Turn && !Stone2.game && !MainMenuScript.computer)) && Input.GetKeyDown (KeyCode.Space) && DiceNumberTextScript.jump == false && Stone.isMoving == false && Stone2.isMoving == false) { // Stone.isMoving == false
			
			//DiceNumberTextScript.sumDices = 0;
			DiceNumberTextScript.diceNumber = 0;
			float dirX = Random.Range (0, 800);
			float dirY = Random.Range (0, 800);
			float dirZ = Random.Range (0, 800);
            
			float x = diceCam.transform.position.x + 0.1f + 7;
			float y = diceCam.transform.position.y + 2 - 6;
			float z = diceCam.transform.position.z - 0.5f;

			//Debug.Log(diceCam.transform.position);
			transform.position = new Vector3 (x, y, z);
			transform.rotation = Quaternion.identity;
			rb.AddForce (transform.up * 550);
			rb.AddTorque (dirX, dirY, dirZ);
			DiceNumberTextScript.jump = true;
			//
			if (Stone.player1Turn)
			{
				DiceNumberTextScript.nrRolledDices1++; // player round(nr of times the dice is rolled)
													  //
			} else if (Stone2.player2Turn)
            {
				DiceNumberTextScript.nrRolledDices2++;
            }
		}
	}
}
