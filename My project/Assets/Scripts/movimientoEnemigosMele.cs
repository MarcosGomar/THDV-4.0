using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform target; 
    public float speed = 5f; 
    public GameObject sword; 

    void Update(){
        if (target != null){
            Vector3 direction = target.position - transform.position;
            direction.y = 0; 
            transform.position += direction.normalized * speed * Time.deltaTime;
        }
    }

    private void OnTriggerEnter(Collider other){
        if (other.gameObject == sword){
            Destroy(gameObject);
        }
    }
}
