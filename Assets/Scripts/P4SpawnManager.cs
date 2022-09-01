using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P4SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject powerupPrefab;
    private float spawnRange = 9.0f;
    public int enemyCount;
    public int waveNumber;

    // Start is called before the first frame update
    void Start()
    {
        if ((Stone.player1Turn && Stone.game && Stone.game4Turn) || (Stone2.player2Turn && Stone2.game && !MainMenuScript.computer && Stone2.game4Turn))
        {
            //SpawnEnemyWave(waveNumber);
            Instantiate(powerupPrefab, GenerateSpawnPosition(), powerupPrefab.transform.rotation);
        }
    }

    void SpawnEnemyWave(int nrEnemies)
    {
        for(int i = 0; i < nrEnemies; i++)
        {
            Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
        }
    }
    // Update is called once per frame
    void Update()
    {
        if ((Stone.player1Turn && Stone.game && Stone.game4Turn) || (Stone2.player2Turn && Stone2.game && !MainMenuScript.computer && Stone2.game4Turn))
        {
            enemyCount = FindObjectsOfType<P4Enemy>().Length;
            if (enemyCount == 0)
            {
                waveNumber = P4PlayerController.level + 1;
                SpawnEnemyWave(waveNumber);
                Instantiate(powerupPrefab, GenerateSpawnPosition(), powerupPrefab.transform.rotation);
            }
        }
    }

    private Vector3 GenerateSpawnPosition()
    {
        float spawnPosX = Random.Range((-spawnRange + P4PlayerController.x), (spawnRange + P4PlayerController.x));
        float spawnPosZ = Random.Range((-spawnRange + P4PlayerController.z), (spawnRange + P4PlayerController.z));

        Vector3 randomPosition = new Vector3(spawnPosX, P4PlayerController.y, spawnPosZ);

        return randomPosition;
    }
}
