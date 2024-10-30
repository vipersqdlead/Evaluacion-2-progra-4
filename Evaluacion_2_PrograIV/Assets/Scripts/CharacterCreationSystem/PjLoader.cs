using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PjLoader : MonoBehaviour
{
    [Header("Character Info")]
    public TMP_Text charName;
    public TMP_Text charAge;
    public TMP_Text charCarID;

    public string userID;
    public string charEntryID;
    [SerializeField] TMP_Text message;

    public void Load()
    {
        SaveSystem saveSystem = new SaveSystem();
        string _jsonID = userID + "_" + charEntryID;
        CharSheet pjSheet = saveSystem.LoadPJSheet(_jsonID);
        if(pjSheet != null)
        {
            this.charName.text = "Character Name: " + pjSheet.charName;
            this.charAge.text = "Character Age: " + pjSheet.charAge;
            this.charCarID.text = "Car Variant: " + pjSheet.charCarID;
            MenuSFX.instance.Start_();
        }
        else if(pjSheet == null)
        {
            ChangeTextMessage("Data not found", Color.red);
            MenuSFX.instance.Error();
        }
    }
    public void ChangeTextMessage(string text, Color color)
    {
        message.text = text;
        message.color = color;
    }
}
