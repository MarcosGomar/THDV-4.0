using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class VidaJugadoryTorre : MonoBehaviour
{
    public ValoresVidaSO vidaEntidad; 
    public TextMeshProUGUI healthText;
    private int currentHealth;
    private float collisionTime = 0f;

    void Start()
    {
        currentHealth = vidaEntidad.maxHealth;
        TextoVida();
    }

    public void Daño(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            ManejarMuerte();
        }
        TextoVida();
    }

    void ManejarMuerte()
    {
        if (vidaEntidad.entidadTipo == "Jugador")
        {
            currentHealth = 0;
            SceneManager.LoadScene("Main Menu");
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        else if (vidaEntidad.entidadTipo == "Torre")
        {
            currentHealth = 0;
            SceneManager.LoadScene("Main Menu");
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }

    void TextoVida()
    {
        healthText.text = vidaEntidad.entidadTipo + ": " + currentHealth.ToString();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemigo")
        {
            Daño(vidaEntidad.damageAmount);
            collisionTime = 0f;
        }
    }

    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Enemigo")
        {
            collisionTime += Time.deltaTime;
            if (collisionTime >= 6f)
            {
                Daño(vidaEntidad.damageAmount);
                collisionTime = 0f;
            }
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Enemigo")
        {
            collisionTime = 0f;
        }
    }
}
