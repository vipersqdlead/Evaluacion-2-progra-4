using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LangMgrSingleton: MonoBehaviour
{
    public static LangMgrSingleton instance;
    Dictionary<Vector2Int, string> localizedText;
    public Language currentLang;

    public enum Language
    {
        ID,
        ENG,
        ESP
    }

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(this);
        }

        DontDestroyOnLoad(this);
        CSVHandler csvH = new CSVHandler("LanguageFile");
        localizedText = localizedTextTable(csvH.ReadFromCSV());
    }


    Dictionary<Vector2Int, string> localizedTextTable(List<string[]> csvData)
    {
        Dictionary<Vector2Int, string> tableDictionary = new Dictionary<Vector2Int, string>();

        for (int i = 0; i < csvData.Count; i++)
        {
            string[] line = csvData[i];

            for (int j = 0; j < line.Length; j++)
            {
                Vector2Int pos = new Vector2Int(i, j);

                tableDictionary.Add(pos, line[j]);
            }
        }

        return tableDictionary;
    }

    public string GetLocalizedText(int ID)
    {
        string str;
        Vector2Int v2i = new Vector2Int(ID, (int)currentLang);
        localizedText.TryGetValue(v2i, out str);
        return str;
    }

    public void ChangeLanguage()
    {
        currentLang++;
        if((int)currentLang > Enum.GetValues(typeof(Language)).Length - 1)
        {
            currentLang = (Language)1;
        }
        SetLanguage((int)currentLang);
    }

    public void SetLanguage(int newLang)
    {
        currentLang = (Language)newLang;
        if(OnLangChange != null)
        {
            OnLangChange(newLang);
        }
    }

    public delegate void LangChangeAction(int newLang);
    public static event LangChangeAction OnLangChange;
}
