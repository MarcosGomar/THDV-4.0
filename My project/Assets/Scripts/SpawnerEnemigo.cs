using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab; // Prefab del enemigo que vas a instanciar
    public Transform spawnPoint;   // Punto fijo donde el enemigo aparecerá
    public float spawnInterval = 3f; // Tiempo entre spawns

    private float spawnTimer;

    void Start(){
        spawnTimer = spawnInterval; // Inicializamos el temporizador
    }

    void Update(){
        spawnTimer -= Time.deltaTime; // Reducimos el tiempo con cada frame

        if (spawnTimer <= 0){
            SpawnEnemy(); // Generamos un enemigo
            spawnTimer = spawnInterval; // Reseteamos el temporizador
        }
    }

    void SpawnEnemy(){
        // Instanciamos el enemigo en el punto fijo de spawn
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
