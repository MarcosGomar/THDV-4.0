using UnityEngine;

public class Arrow : MonoBehaviour
{
    public float speed = 10f;          // Velocidad de la flecha
    public float pushDistance = 0.05f; // Distancia de empuje (5 cm)
    public int damage = 1;             // Daño que causa la flecha

    void Update()
    {
        // Mover la flecha hacia adelante
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    void OnCollisionEnter(Collision collision)
    {
        // Verificar si la flecha golpea al jugador
        if (collision.collider.CompareTag("Player"))
        {
            // Aplicar daño al jugador
            VidaJugadoryTorre playerHealth = collision.collider.GetComponent<VidaJugadoryTorre>();
            if (playerHealth != null)
            {
                playerHealth.Daño(damage);
            }

            // Empujar al jugador
            Rigidbody playerRb = collision.collider.GetComponent<Rigidbody>();
            if (playerRb != null)
            {
                Vector3 pushDirection = (collision.collider.transform.position - transform.position).normalized;
                playerRb.MovePosition(collision.collider.transform.position + pushDirection * pushDistance);
            }
        }

        // Destruir la flecha tras cualquier colisión
        Destroy(gameObject);
    }
}
