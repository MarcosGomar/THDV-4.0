using System.Collections;
using UnityEngine;

public class EnemyArcher : MonoBehaviour
{
    public GameObject arrowPrefab;    // Prefab de la flecha
    public Transform firePoint;       // Punto desde donde se dispara la flecha
    public float shootInterval = 10f; // Intervalo de disparo en segundos

    private float shootTimer;
    private Transform player;

    void Start()
    {
        shootTimer = shootInterval;
        // Obtener referencia al jugador por etiqueta "Player"
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        shootTimer -= Time.deltaTime;

        if (shootTimer <= 0f)
        {
            ShootArrow();
            shootTimer = shootInterval;
        }
    }

    void ShootArrow()
    {
        // Orientar el firePoint hacia el jugador
        firePoint.LookAt(player.position);

        // Instanciar la flecha en el punto de disparo con la rotación del firePoint
        GameObject arrow = Instantiate(arrowPrefab, firePoint.position, firePoint.rotation);
        arrow.SetActive(true); // Asegurarse de que la flecha esté activada al crearse
    }
}
