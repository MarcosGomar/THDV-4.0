using UnityEngine;

public class Arrow : MonoBehaviour
{
    public float speed = 10f;          
    public float pushDistance = 1f; 
    public int damage = 1;           

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            // Verificar si el player tiene el escudo activo
            VidaJugadoryTorre playerHealth = collision.collider.GetComponent<VidaJugadoryTorre>();
            if (playerHealth != null)
            {
                Transform shieldTransform = collision.collider.transform.Find("Escudo");
                if (shieldTransform != null && shieldTransform.gameObject.activeInHierarchy)
                {
                    // Si el escudo está activo, destruimos la flecha y no aplicamos daño
                    Destroy(gameObject);
                    return;
                }
                else
                {
                    // Si no tiene escudo, aplicar daño y empuje
                    playerHealth.Daño(damage);
                }
            }

            Rigidbody playerRb = collision.collider.GetComponent<Rigidbody>();
            if (playerRb != null)
            {
                // Calcula la dirección del empuje sin afectar la componente Y
                Vector3 pushDirection = (collision.collider.transform.position - transform.position).normalized;
                pushDirection.y = 0; // Asegúrate de que el empuje no afecte la componente Y

                // Mueve al jugador en la dirección deseada sin cambiar su altura
                playerRb.MovePosition(collision.collider.transform.position + pushDirection * pushDistance);
            }
        }
        else
        {
            // Destruir la flecha al colisionar con cualquier otra cosa
            Destroy(gameObject);
        }
    }
}
