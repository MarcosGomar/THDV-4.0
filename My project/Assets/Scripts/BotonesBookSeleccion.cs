using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BotonesBookSeleccion : MonoBehaviour
{
    public Button botonBallesta; 
    public Button botonTrebuchet; 
    public TextMeshProUGUI textoBotonBallesta;
    public TextMeshProUGUI textoBotonTrebuchet;

    private bool botonBallestaEnUso = true;
    private bool botonTrebuchetComprado = false;
    private bool botonTrebuchetEnUso = false;

    public int costoCompraBotonTrebuchet = 100;

    private void Start()
    {
        botonBallestaEnUso = PlayerPrefs.GetInt("botonBallestaEnUso", 1) == 1;
        botonTrebuchetComprado = PlayerPrefs.GetInt("botonTrebuchetComprado", 0) == 1;
        botonTrebuchetEnUso = PlayerPrefs.GetInt("botonTrebuchetEnUso", 0) == 1;

        ActualizarTextoBotonBallesta();
        ActualizarTextoBotonTrebuchet();

        botonBallesta.onClick.AddListener(() => GestionarBotonBallesta());
        botonTrebuchet.onClick.AddListener(() => GestionarBotonTrebuchet());
    }

    private void GestionarBotonBallesta()
    {
        if (!botonBallestaEnUso)
        {
            botonBallestaEnUso = true;
            botonTrebuchetEnUso = false;
            ActualizarTextoBotonBallesta();
            ActualizarTextoBotonTrebuchet();
            SaveButtonStates();
        }
    }

    private void GestionarBotonTrebuchet()
    {
        if (Monedas.instancia == null)
        {
            Debug.Log("El Objeto Monedas no está presente, juega una partida y mata enemigos para conseguir");
            return;
        }

        if (!botonTrebuchetComprado)
        {
            if (Monedas.instancia.monedas >= costoCompraBotonTrebuchet)
            {
                Monedas.instancia.AñadirMonedas(-costoCompraBotonTrebuchet);
                botonTrebuchetComprado = true;
                botonTrebuchetEnUso = true;
                botonBallestaEnUso = false;
                ActualizarTextoBotonBallesta();
                ActualizarTextoBotonTrebuchet();
                SaveButtonStates();
            }
            else
            {
                Debug.Log("No tienes suficientes monedas para comprar este botón.");
            }
        }
        else if (!botonTrebuchetEnUso)
        {
            botonTrebuchetEnUso = true;
            botonBallestaEnUso = false;
            ActualizarTextoBotonBallesta();
            ActualizarTextoBotonTrebuchet();
            SaveButtonStates();
        }
    }

    private void ActualizarTextoBotonBallesta()
    {
        if (botonBallestaEnUso)
        {
            textoBotonBallesta.text = "En uso";
        }
        else
        {
            textoBotonBallesta.text = "Seleccionar";
        }
    }

    private void ActualizarTextoBotonTrebuchet()
    {
        if (!botonTrebuchetComprado)
        {
            textoBotonTrebuchet.text = "Comprar: " + costoCompraBotonTrebuchet;
        }
        else if (botonTrebuchetEnUso)
        {
            textoBotonTrebuchet.text = "En uso";
        }
        else
        {
            textoBotonTrebuchet.text = "Seleccionar";
        }
    }

    private void SaveButtonStates()
    {
        PlayerPrefs.SetInt("botonBallestaEnUso", botonBallestaEnUso ? 1 : 0);
        PlayerPrefs.SetInt("botonTrebuchetComprado", botonTrebuchetComprado ? 1 : 0);
        PlayerPrefs.SetInt("botonTrebuchetEnUso", botonTrebuchetEnUso ? 1 : 0);
        PlayerPrefs.Save();
    }
}
