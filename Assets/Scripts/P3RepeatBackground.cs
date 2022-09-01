using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P3RepeatBackground : MonoBehaviour
{
    private Vector3 startPos;
    private float repeatWidth;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        repeatWidth = GetComponent<BoxCollider>().size.x / 2;
    }

    // Update is called once per frame
    void Update()
    {
        if ((Stone.player1Turn && Stone.game && Stone.game3Turn) || (Stone2.player2Turn && Stone2.game && !MainMenuScript.computer && Stone2.game3Turn))
        {
            if (transform.position.x < startPos.x - repeatWidth)
            {
                transform.position = startPos;
            }
        }
    }
}
