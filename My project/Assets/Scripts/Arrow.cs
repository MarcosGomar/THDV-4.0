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
                Transform shieldTransform = collision.collider.transform.Find("Escudo");
                if (shieldTransform != null && shieldTransform.gameObject.activeInHierarchy)
                {
                    Destroy(gameObject);
                    return;
                }
                else
                {
                    playerHealth.Daño(damage);
                }
            }

            Rigidbody playerRb = collision.collider.GetComponent<Rigidbody>();
            if (playerRb != null)
            {
                Vector3 pushDirection = (collision.collider.transform.position - transform.position).normalized;
                pushDirection.y = 0;

                playerRb.MovePosition(collision.collider.transform.position + pushDirection * pushDistance);
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
