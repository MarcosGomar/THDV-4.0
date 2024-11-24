using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CSVReader : MonoBehaviour
{
    public TextAsset textAssetData;

    [System.Serializable]
    public class VidaExcel
    {
        public string Name;
        public int Health;
    }

    [System.Serializable]
    public class VidaExcelLista
    {
        public VidaExcel[] vida;
    }

    public VidaExcelLista miVidaExcelLista = new VidaExcelLista();

    void Start()
    {
        ReadCSV();
    }

    void ReadCSV()
    {
        string[] lines = textAssetData.text.Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);
        int tableSize = lines.Length - 1;
        miVidaExcelLista.vida = new VidaExcel[tableSize];

        for (int i = 1; i < lines.Length; i++)
        {
            string[] row = lines[i].Split(new string[] { ";" }, StringSplitOptions.None);
            miVidaExcelLista.vida[i - 1] = new VidaExcel();
            miVidaExcelLista.vida[i - 1].Name = row[0];
            int.TryParse(row[1], out miVidaExcelLista.vida[i - 1].Health);
            Debug.Log($"Name: {miVidaExcelLista.vida[i - 1].Name}, Health: {miVidaExcelLista.vida[i - 1].Health}");
        }
    }
}