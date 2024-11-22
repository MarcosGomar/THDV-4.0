using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DañoPorContacto : MonoBehaviour
{
    public int damagePerSecond = 10;
    private VidaJugadoryTorre vidaJugador;
    private bool estaEnContacto = false;
    private float intervaloDaño = 1f;
    private float tiempoDesdeUltimoDaño = 0f;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            vidaJugador = other.gameObject.GetComponent<VidaJugadoryTorre>();
            if (vidaJugador != null)
            {
                estaEnContacto = true;
                tiempoDesdeUltimoDaño = 0f;
            }
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (estaEnContacto)
        {
            tiempoDesdeUltimoDaño += Time.deltaTime;

            if (tiempoDesdeUltimoDaño >= intervaloDaño)
            {
                vidaJugador.Daño(damagePerSecond);
                tiempoDesdeUltimoDaño = 0f;
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            estaEnContacto = false;
            tiempoDesdeUltimoDaño = 0f;
        }
    }
}
