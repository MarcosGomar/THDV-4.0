using System.Collections.Generic;
using UnityEngine;

public class ArrowPool : MonoBehaviour
{
    public static ArrowPool Instance;
    public GameObject arrowPrefab; 
    public int poolSize = 10;
    private List<GameObject> arrows;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        arrows = new List<GameObject>();

        for (int i = 0; i < poolSize; i++)
        {
            GameObject arrow = Instantiate(arrowPrefab);
            arrow.SetActive(false);
            arrows.Add(arrow);
        }
    }
    
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
        GameObject newArrow = Instantiate(arrowPrefab);
        newArrow.SetActive(true);
        arrows.Add(newArrow);
        return newArrow;
    }
}
