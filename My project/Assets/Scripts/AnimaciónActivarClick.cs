using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimacionActivarClick : MonoBehaviour
{
    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        if (animator == null)
        {
            Debug.LogError("No se encontró el componente Animator en el GameObject.");
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (animator != null)
            {
                Debug.Log("Click detectado, activando animación.");
                animator.SetTrigger("Ataque");
            }
        }
    }
}
