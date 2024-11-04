using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[CreateAssetMenu]
public class BallestaSO : ScriptableObject
{
    public float distanciaParaSubir = 1f;
    public float tiempoParaSubir = 1f;
    public float velocidadDeSubida = 2f;
    public float velocidadDeBajada = 2f;
    public float tiempoDeEsperaParaRegresar = 10f;
    public int vidaInicialTorreEnemiga = 100;
    public string textoInteraccion = "Mantén E para interactuar y disparar";
    public string textoVidaTorre = "Torre Enemiga: ";
}
