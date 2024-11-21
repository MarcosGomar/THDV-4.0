using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CambioDeArmaSegunBotonesBook : MonoBehaviour
{
    public GameObject ballesta;    // Referencia al objeto Ballesta
    public GameObject trebuchet;   // Referencia al objeto Trebuchet

    public Transform posicionA;    // Posición para el arma seleccionada
    public Transform posicionB;    // Posición para el arma no seleccionada

    void Start()
    {
        // Cargar la selección del arma desde PlayerPrefs
        bool ballestaEnUso = PlayerPrefs.GetInt("botonBallestaEnUso", 1) == 1;
        bool trebuchetEnUso = PlayerPrefs.GetInt("botonTrebuchetEnUso", 0) == 1;

        if (ballestaEnUso)
        {
            // Colocar Ballesta en posicionA y Trebuchet en posicionB
            ballesta.transform.position = posicionA.position;
            trebuchet.transform.position = posicionB.position;
        }
        else if (trebuchetEnUso)
        {
            // Colocar Trebuchet en posicionA y Ballesta en posicionB
            trebuchet.transform.position = posicionA.position;
            ballesta.transform.position = posicionB.position;
        }
        else
        {
            // Por defecto, colocar Ballesta en posicionA y Trebuchet en posicionB
            ballesta.transform.position = posicionA.position;
            trebuchet.transform.position = posicionB.position;
        }
    }
}
