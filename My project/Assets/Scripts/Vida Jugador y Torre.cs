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
        }
    }
}
