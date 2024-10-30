using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class SaveSystem
{
    public const string pjSheetKey ="pjSheetKey";
    
    public void SavePjSheet(CarSheetStruct pjSheetStruct, string id)
    {
        //Inicializar un nuevo pjSheet con los valores de nuestras variables
        CharSheet pjSheet = new CharSheet(pjSheetStruct);

        //Estamos convirtiendo la clase a JSON que es siempre de tipo string
        string data = JsonUtility.ToJson(pjSheet);

        //Estamos guardando el json en player prefs
        StreamData.WriteFile(pjSheetKey + id, data);
        //PlayerPrefs.SetString(pjSheetKey + id, data);
    }

    public CharSheet LoadPJSheet(string id)
    {
        //Recuperando el json mediante playerPrefs
        string data = StreamData.ReadFile(pjSheetKey + id);
        //string data = PlayerPrefs.GetString(pjSheetKey + id, "NULL");

        if (data == "NULL")
        {
            Debug.Log("Data not found");
            return null;
        }

        //Estamos convirtiendo el Json recuperado a su clase original y guardamos la info en pjSheet
        CharSheet pjSheet = JsonUtility.FromJson<CharSheet>(data);

        return pjSheet;

    }
}
