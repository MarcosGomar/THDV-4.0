using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CambioDeArmaSegunBotonesBook : MonoBehaviour
{
    public GameObject ballesta;   
    public GameObject trebuchet; 

    public Transform posicionA; 
    public Transform posicionB;

    void Start()
    {
        bool ballestaEnUso = BotonesBookSeleccion.EsBallestaEnUso();
        bool trebuchetEnUso = BotonesBookSeleccion.EsTrebuchetEnUso();

        if (ballestaEnUso)
        {
            ballesta.transform.position = posicionA.position;
            trebuchet.transform.position = posicionB.position;
        }
        else if (trebuchetEnUso)
        {
            trebuchet.transform.position = posicionA.position;
            ballesta.transform.position = posicionB.position;
        }
        else
        {
            ballesta.transform.position = posicionA.position;
            trebuchet.transform.position = posicionB.position;
        }
    }
}
