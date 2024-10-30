using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PrefabText : MonoBehaviour
{
    public TMP_Text text;
    public int ID;
    public LangMgrSingleton langMgr;

    // Start is called before the first frame update
    void Awake()
    {
        text = GetComponent<TMP_Text>();
    }

    void SetText(string newText)
    {
        text.text = newText;
    }

    void UpdateText(int lang)
    {
        SetText(langMgr.GetLocalizedText(ID));
    }

    public void ChangeText(int newTextID)
    {
        ID = newTextID;
        SetText(langMgr.GetLocalizedText(ID));
    }

    private void Start()
    {
        langMgr = LangMgrSingleton.instance;
        LangMgrSingleton.OnLangChange += UpdateText;
        UpdateText((int)langMgr.currentLang);
    }

    private void OnDestroy()
    {
        LangMgrSingleton.OnLangChange -= UpdateText;
    }
}
