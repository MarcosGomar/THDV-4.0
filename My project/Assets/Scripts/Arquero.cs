using System.Collections;
using UnityEngine;

public class EnemyArcher : MonoBehaviour
{
    public GameObject arrowPrefab;
    public Transform firePoint;
    public float shootInterval = 10f; 
    private float shootTimer;
    private Transform player;

    void Start()
    {
        shootTimer = shootInterval;
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
        Vector3 adjustedTarget = player.position;
        adjustedTarget.y += 1f;
        firePoint.LookAt(adjustedTarget);
        GameObject arrow = Instantiate(arrowPrefab, firePoint.position, firePoint.rotation);
        arrow.SetActive(true); 
    }
}
