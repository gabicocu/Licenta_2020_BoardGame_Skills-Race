using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P2MoveForward : MonoBehaviour
{
    public float speed = 40.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //speed = 40f + P2DetectCollisions.level * 5;
        if ((Stone.player1Turn && Stone.game && Stone.game2Turn) || (Stone2.player2Turn && Stone2.game && Stone2.game2Turn) && !MainMenuScript.computer)
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
    }
}
