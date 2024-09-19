using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab; 
    public Transform spawnPoint;  
    public float spawnInterval = 3f;

    private float spawnTimer;

    void Start(){
        spawnTimer = spawnInterval;
    }

    void Update(){
        spawnTimer -= Time.deltaTime;

        if (spawnTimer <= 0){
            SpawnEnemy();
            spawnTimer = spawnInterval;
        }
    }

    void SpawnEnemy(){
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
