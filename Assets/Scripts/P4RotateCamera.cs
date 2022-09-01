using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P4RotateCamera : MonoBehaviour
{
    public float rotationSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if ((Stone.player1Turn && Stone.game && Stone.game4Turn) || (Stone2.player2Turn && Stone2.game && !MainMenuScript.computer && Stone2.game4Turn))
        {
            float horizontalInput = Input.GetAxis("Horizontal");

            transform.Rotate(Vector3.up, horizontalInput * rotationSpeed * Time.deltaTime);
        }
    }
}
