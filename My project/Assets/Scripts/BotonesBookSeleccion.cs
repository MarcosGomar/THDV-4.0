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
            botonTrebuchetEnUso = false; // Si seleccionas este, el otro deja de estar en uso
            ActualizarTextoBotonBallesta();
            ActualizarTextoBotonTrebuchet();
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
            }
            else
            {
                Debug.Log("No tienes suficientes monedas para comprar este botón.");
            }
        }
        else if (!botonTrebuchetEnUso)
        {
            botonTrebuchetEnUso = true;
            botonBallestaEnUso = false; // Desactiva el uso del otro botón
            ActualizarTextoBotonBallesta();
            ActualizarTextoBotonTrebuchet();
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
}
