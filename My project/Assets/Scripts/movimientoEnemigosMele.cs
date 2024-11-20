using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform target;
    public float speed = 5f; 
    public GameObject sword; 
    //aca irian los elementos para las monedas
    

    void Update()
    {
        if (target != null)
        {
            Vector3 direction = target.position - transform.position;
            direction.y = 0;
            transform.position += direction.normalized * speed * Time.deltaTime;
            transform.LookAt(new Vector3(target.position.x, transform.position.y, target.position.z));
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == sword)
        {
            //agregar droppable de monedas
            Destroy(gameObject);
        }
    }
}
