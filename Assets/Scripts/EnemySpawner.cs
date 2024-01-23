using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject obstaclePrefab;
    public int waveNumber = 1;
    public int enemyCount;
    public float startDelay = 2f;
    public float repeatRate = 2f;
    //public bool isSpawning;
    public float spawnRange = 9;
    public GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        SpawnEnemyWave(waveNumber);
        //isSpawning = true;
        
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<EnemyFollowPlayer>().Length;
        if (enemyCount == 0)
        {
            waveNumber++;
            SpawnEnemyWave(enemyCount);
        }

    }


    /*IEnumerator SpawnDelay()
    {
        yield return new WaitForSeconds(repeatRate);
        isSpawning = true;
    }*/
    public Vector3 NewSpawnPos()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);
        Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ);
        return randomPos;
    }
    void SpawnEnemyWave(int enemiesToSpawn)
    {
        if (gameManager.isGameActive == true)
        {
            for (int i = 0; i < enemiesToSpawn; i++)
            {
                Instantiate(obstaclePrefab, NewSpawnPos(), transform.rotation);
            }
        }
    }
    
}
