using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P3SpawnManager : MonoBehaviour
{
    public GameObject obstaclePrefab;
    private Vector3 spawnPos = new Vector3(25, -8, -5);
    private float startDelay = 2;
    private float repeatRate = 2;
    private P3PlayerController playerControllerScript;

    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<P3PlayerController>();
        InvokeRepeating("SpawnObstacle", startDelay, repeatRate);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnObstacle()
    {
        //if(playerControllerScript.gameOver == false)
        if ((Stone.player1Turn && Stone.game && Stone.game3Turn) || (Stone2.player2Turn && Stone2.game && !MainMenuScript.computer && Stone2.game3Turn))
        {
            spawnPos = new Vector3(P3PlayerController.x + 25, P3PlayerController.y, P3PlayerController.z);
            //Debug.Log(spawnPos);
            {
                Instantiate(obstaclePrefab, spawnPos, obstaclePrefab.transform.rotation);
            }
        }

    }
}
