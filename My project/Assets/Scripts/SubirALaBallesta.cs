using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class SubirAlObjeto : MonoBehaviour
{
    public GameObject objetoASubir;
    public GameObject jugador;
    public BallestaSO ballestaConfig; 
    public TextMeshProUGUI textoVidaTorreEnemiga;
    public TextMeshProUGUI textoInteraccion;

    private float contadorTiempo = 0f;
    private bool cercaDelObjeto = false;
    private bool estaSubiendo = false;
    private bool estaBajando = false;
    private bool regresando = false; 
    private Vector3 posicionInicial;
    private Vector3 posicionObjetivo;
    private int vidaTorreEnemiga;

    void Start()
    {
        posicionInicial = transform.position;
        vidaTorreEnemiga = ballestaConfig.vidaInicialTorreEnemiga;
        ActualizarTextoVida();

        if (textoInteraccion != null)
        {
            textoInteraccion.gameObject.SetActive(false); 
            textoInteraccion.text = ballestaConfig.textoInteraccion; 
        }
    }

    void Update()
    {
        float distancia = Vector3.Distance(jugador.transform.position, objetoASubir.transform.position);
        Debug.Log("Distancia al objeto: " + distancia);  

        if (distancia <= ballestaConfig.distanciaParaSubir) 
        {
            cercaDelObjeto = true;
        }
        else
        {
            cercaDelObjeto = false;
        }

        if (textoInteraccion != null)
        {
            textoInteraccion.gameObject.SetActive(cercaDelObjeto);
        }

        Debug.Log("¿Está cerca del objeto?: " + cercaDelObjeto);  

        if (cercaDelObjeto && Input.GetKey(KeyCode.E) && !regresando)
        {
            contadorTiempo += Time.deltaTime;

            if (contadorTiempo >= ballestaConfig.tiempoParaSubir && !estaSubiendo)
            {
                Subir();
            }
        }
        else
        {
            contadorTiempo = 0f;
        }

        if (estaSubiendo)
        {
            transform.position = Vector3.Lerp(transform.position, posicionObjetivo, Time.deltaTime * ballestaConfig.velocidadDeSubida); 

            if (Vector3.Distance(transform.position, posicionObjetivo) < 0.1f)
            {
                estaSubiendo = false;
                Invoke("Bajar", 0.1f);
                Invoke("RegresarAPosicionInicial", ballestaConfig.tiempoDeEsperaParaRegresar); 
            }
        }

        if (estaBajando)
        {
            transform.position = Vector3.Lerp(transform.position, posicionObjetivo, Time.deltaTime * ballestaConfig.velocidadDeBajada); 

            if (Vector3.Distance(transform.position, posicionObjetivo) < 0.1f)
            {
                estaBajando = false;
                ReducirVidaTorre();
            }
        }

        if (regresando)
        {
            transform.position = Vector3.Lerp(transform.position, posicionObjetivo, Time.deltaTime * ballestaConfig.velocidadDeBajada); 

            if (Vector3.Distance(transform.position, posicionObjetivo) < 0.1f)
            {
                regresando = false;
                Debug.Log("El objeto ha regresado a su posición inicial");
            }
        }
    }

    void Subir()
    {
        Debug.Log("Subiendo al objeto");
        posicionObjetivo = objetoASubir.transform.position + new Vector3(100, 10, 0);
        estaSubiendo = true;
    }

    void Bajar()
    {
        Debug.Log("Bajando del objeto");
        posicionObjetivo = objetoASubir.transform.position + new Vector3(100, -10, 0);
        estaBajando = true;
    }

    void RegresarAPosicionInicial()
    {
        Debug.Log("Regresando el objeto a su posición original");
        posicionObjetivo = posicionInicial; 
        regresando = true; 
    }

    void ReducirVidaTorre() //he tenido que hardcodear el da;o a la torre enemiga por que los colliders no estaban funcionando
    {
        vidaTorreEnemiga -= ballestaConfig.dañoTorre; // Utiliza el daño configurado
        if (vidaTorreEnemiga <= 0)
        {
            vidaTorreEnemiga = 0;
            SceneManager.LoadScene("Main Menu");
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        ActualizarTextoVida();
    }

    void ActualizarTextoVida()
    {
        if (textoVidaTorreEnemiga != null)
        {
            textoVidaTorreEnemiga.text = vidaTorreEnemiga + ballestaConfig.textoVidaTorre ; 
        }
    }
}
