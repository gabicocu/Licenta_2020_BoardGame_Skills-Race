using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceScript2 : MonoBehaviour {

	static Rigidbody rb;
	public static Vector3 diceVelocity;
	Camera diceCam;

	// Use this for initialization
	void Start () {

		rb = GetComponent<Rigidbody> ();
		diceCam = GameObject.Find("DiceCamera").GetComponent<Camera>();
	}
	
	// Update is called once per frame
	public void Update () {
		diceVelocity = rb.velocity;
		if (Stone2.player2Turn && MainMenuScript.computer && DiceNumberTextScript.jump == false && DiceNumberTextScript.jump2 == false && Stone.isMoving == false && Stone2.isMoving == false && DiceNumberTextScript.nrRolledDices2 == Stone2.nrMoves)
        {
			DiceNumberTextScript.jump2 = true;
			DiceNumberTextScript.pressed = true;
			DiceNumberTextScript.sumDices = 0;
			DiceNumberTextScript.diceNumber2 = 0;
			float dirX = Random.Range(0, 700);
			float dirY = Random.Range(0, 700);
			float dirZ = Random.Range(0, 700);
			float x = diceCam.transform.position.x + 7;
			float y = diceCam.transform.position.y + 2 - 6;
			float z = diceCam.transform.position.z + 0.5f;
			transform.position = new Vector3(x, y, z);
			transform.rotation = Quaternion.identity;
			rb.AddForce(transform.up * 600);
			rb.AddTorque(dirX, dirY, dirZ);
			
		}
		else if (((Stone.player1Turn && !Stone.game) || (Stone2.player2Turn && !Stone2.game && !MainMenuScript.computer)) && Input.GetKeyDown (KeyCode.Space) && DiceNumberTextScript.jump2 == false && Stone.isMoving == false && Stone2.isMoving == false) {

			//
			//Stone.movePlayer = false;
			//DiceNumberTextScript.nrRolledDices++;
			//

			DiceNumberTextScript.pressed = true;
			DiceNumberTextScript.sumDices = 0;
			DiceNumberTextScript.diceNumber2 = 0;
			float dirX = Random.Range (0, 700);
			float dirY = Random.Range (0, 700);
			float dirZ = Random.Range (0, 700);
			float x = diceCam.transform.position.x + 7;
			float y = diceCam.transform.position.y + 2 - 6;
			float z = diceCam.transform.position.z + 0.5f;
			transform.position = new Vector3 (x, y, z);
			transform.rotation =  Quaternion.identity;
			rb.AddForce (transform.up * 600);
			rb.AddTorque (dirX, dirY, dirZ);
			DiceNumberTextScript.jump2 = true;
		}
	}
}
