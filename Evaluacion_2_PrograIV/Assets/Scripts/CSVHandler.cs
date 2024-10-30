using System;
using System.IO;
using System.Collections.Generic;
using UnityEngine;

public class CSVHandler
{
    // Ruta del archivo CSV
    private string filePath;

    // Constructor para inicializar la ruta
    public CSVHandler(string fileName)
    {
        filePath = Path.Combine(Application.streamingAssetsPath, fileName);
    }

    // M�todo para escribir datos en el CSV
    public void WriteToCSV(List<string[]> data)
    {
        try
        {
            using (StreamWriter sw = new StreamWriter(filePath + ".csv"))
            {
                foreach (var row in data)
                {
                    string line = string.Join(",", row); // Une los valores separados por comas
                    sw.WriteLine(line);
                }
            }
            Debug.Log("Datos escritos en el archivo CSV con �xito.");
        }
        catch (Exception e)
        {
            Debug.LogError($"Error al escribir en el archivo CSV: {e.Message}");
        }
    }

    // M�todo para leer datos del CSV
    public List<string[]> ReadFromCSV()
    {
        List<string[]> data = new List<string[]>();

        try
        {
            using (StreamReader sr = new StreamReader(filePath + ".csv"))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] row = line.Split(','); // Divide la l�nea en columnas
                    data.Add(row);
                }
            }
            Debug.Log("Datos le�dos del archivo CSV con �xito.");
        }
        catch (Exception e)
        {
            Debug.LogError($"Error al leer el archivo CSV: {e.Message}");
        }

        return data;
    }
}
