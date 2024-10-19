using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class TowerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public TextMeshProUGUI healthText;
    public int damageAmount = 1;

    void Start()
    {
        currentHealth = maxHealth;
        TextoVida();
    }

    public void Daño(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            SceneManager.LoadScene("Main Menu");
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        TextoVida();
    }

    void TextoVida()
    {
        healthText.text = "Torre: " + currentHealth.ToString();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemigo")
        {
            Daño(damageAmount); 
        }
    }
}
