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
            VidaJugadoryTorre playerHealth = collision.collider.GetComponent<VidaJugadoryTorre>();
            if (playerHealth != null)
            {
                playerHealth.Daño(damage);
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
        Destroy(gameObject);
    }
}
