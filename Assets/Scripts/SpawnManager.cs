using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemies;
    public GameObject powerup;
    public GameObject[] powerup2;

    private float zEnemySpawn = 24.0f;
    private float xSpawnRange = 3.60f;
    private float zPowerupSpawnRangeUpper = 7.75f;
    private float zPowerupSpawnRangeLower = 1.54f;
    private float ySpawn = 0.75f;
    //private float ySpawn2 = 1.66f;

    private float startDelay = 3.0f;
    private float enemySpawnTime = 2.0f;
  //  private float powerupSpawnTime = 5.0f;
    private float powerUp2SpawnTime = 3 ;

   

    private PlayerController playerControllerScript;
    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();

        InvokeRepeating("SpawnEnemy", startDelay, enemySpawnTime);
        InvokeRepeating("SpawnPowerup", startDelay, Random.Range(30F, 50F));
        InvokeRepeating("SpawnPowerup2", 1f, powerUp2SpawnTime);


    }

    // Update is called once per frame
    void Update()
    {
       
    }

    void SpawnEnemy()
    {
        if (playerControllerScript.gameOver != true)
        {
            float randomX = Random.Range(-xSpawnRange, xSpawnRange);
            int randomIndex = Random.Range(0, enemies.Length);

            Vector3 spawnPos = new Vector3(randomX, ySpawn, zEnemySpawn);

            Instantiate(enemies[randomIndex], spawnPos, enemies[randomIndex].gameObject.transform.rotation);

        }
       
    }

    void SpawnPowerup()
    {
        if(playerControllerScript.gameOver == false)
        {
            float randomX = Random.Range(-xSpawnRange, xSpawnRange);
            float randomZ = Random.Range(zPowerupSpawnRangeLower, zPowerupSpawnRangeUpper);

            Vector3 spawnPos = new Vector3(randomX, ySpawn, randomZ);
            Instantiate(powerup, spawnPos, powerup.gameObject.transform.rotation);
        }
        
    }

    void SpawnPowerup2()
    {
        if (playerControllerScript.gameOver == false)
        {
            int randomIndex = Random.Range(0, powerup2.Length);

            float randomX = Random.Range(-xSpawnRange, xSpawnRange);
            float randomZ = Random.Range(zPowerupSpawnRangeLower, zPowerupSpawnRangeUpper);

            Vector3 spawnPos = new Vector3(0, 1.66f,zEnemySpawn);
            Instantiate(powerup2 [randomIndex], spawnPos, powerup2[randomIndex].gameObject.transform.rotation);
        }

    }
}
