using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public static class StreamData
{
    public static string ReadFile(string fileName)
    {
        string path = Path.Combine(Application.streamingAssetsPath, fileName + ".txt");

        try
        {
            using (StreamReader sr = new StreamReader(path))
            {
                string data = sr.ReadToEnd();
                sr.Close();
                return data;
            }
        }

        catch(FileNotFoundException ex)
        {
            Debug.Log("File not found! " + ex.Message);
        }
        catch(Exception ex)
        {
            Debug.Log(ex.Message);
        }
        return null;
    }

    public static void WriteFile(string fileName, string data)
    {
        string path = Path.Combine(Application.streamingAssetsPath, fileName + ".txt");

        try
        {
            using (StreamWriter sw = new StreamWriter(path))
            {
                sw.Write(data);
                Debug.Log(data);
                sw.Close();
            }
        }
        catch (Exception ex)
        {
            Debug.Log(ex.Message);
        }
    }
}
