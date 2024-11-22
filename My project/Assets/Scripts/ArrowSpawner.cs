using System.Collections.Generic;
using UnityEngine;

public class ArrowPool : MonoBehaviour
{
    public static ArrowPool Instance;

    public GameObject arrowPrefab;  // Prefab de la flecha
    public int poolSize = 10;       // Tamaño de la piscina

    private List<GameObject> arrows;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        arrows = new List<GameObject>();

        // Crear las flechas iniciales en la piscina
        for (int i = 0; i < poolSize; i++)
        {
            GameObject arrow = Instantiate(arrowPrefab);
            arrow.SetActive(false);
            arrows.Add(arrow);
        }
    }

    // Método para obtener una flecha de la piscina
    public GameObject GetArrow()
    {
        foreach (GameObject arrow in arrows)
        {
            if (!arrow.activeInHierarchy)
            {
                arrow.SetActive(true);
                return arrow;
            }
        }

        // Si no hay flechas disponibles, creamos una nueva y la añadimos a la piscina
        GameObject newArrow = Instantiate(arrowPrefab);
        newArrow.SetActive(true);
        arrows.Add(newArrow);
        return newArrow;
    }
}
