using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AsignarValores : MonoBehaviour
{    
    [SerializeField] private MostrarInformacionSO  armaInfo;
    [SerializeField] private Image imagenUI;
    [SerializeField] private TextMeshProUGUI nombreUI;
    [SerializeField] private TextMeshProUGUI danoUI;
    [SerializeField] private TextMeshProUGUI recargaUI;
    //[SerializeField] private TextMeshProUGUI estadoPrototipoUI;
    private void Start()
    {
        if (armaInfo != null)
        {
            AsignarValoresUI();
        }
        else
        {
            Debug.LogWarning("El ScriptableObject 'armaInfo' no está asignado en el inspector.");
        }
    }

    private void AsignarValoresUI()
    {
        imagenUI.sprite = armaInfo.imagen;
        nombreUI.text = armaInfo.nombre;
        danoUI.text = "Daño: " + armaInfo.dano.ToString();
        recargaUI.text = "Recarga: " + armaInfo.recarga.ToString() + " segundos";
        //estadoPrototipoUI.text = armaInfo.estadoPrototipo;
    }
}
