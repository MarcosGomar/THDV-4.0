using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Monedas : MonoBehaviour
{
    public static Monedas instancia;
    public int monedas = 0;
    public TextMeshProUGUI textoMonedas;

    private void Awake()
    {
        if (instancia == null)
        {
            instancia = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        BuscarTextoMonedas();
        ActualizarTextoMonedas();
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        BuscarTextoMonedas(); 
        ActualizarTextoMonedas();
    }

    public void AñadirMonedas(int cantidad)
    {
        monedas += cantidad;
        ActualizarTextoMonedas();
    }

    void ActualizarTextoMonedas()
    {
        if (textoMonedas != null)
        {
            textoMonedas.text = "Monedas: " + monedas.ToString();
        }
    }

    void BuscarTextoMonedas()
    {
        if (SceneManager.GetActiveScene().name == "Book") 
        {
            GameObject textoObj = GameObject.Find("Cantidad monedas");
            if (textoObj != null)
            {
                textoMonedas = textoObj.GetComponent<TextMeshProUGUI>();
            }
        }
        else 
        {
            GameObject textoObj = GameObject.Find("Monedas texto"); 
            if (textoObj != null)
            {
                textoMonedas = textoObj.GetComponent<TextMeshProUGUI>();
            }
        }
    }
}
