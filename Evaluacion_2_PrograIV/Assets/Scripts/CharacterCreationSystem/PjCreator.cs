using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PjCreator : MonoBehaviour
{
    [Header("Character Info")]
    public string charName;
    public string charAge;
    public string charCarID;

    public string gripSkill, driftSkill, cornerEntry, cornerExit, launch, fwdSkill, rwdSkill, awdSkill, rearEngSkill;

    [Header("Item ID")]
    public string userID;
    public string charEntryID;
    public string jsonID;

    [SerializeField] TMPro.TMP_InputField iF_CharName, iF_CharAge, iF_CharCarID, iF_grip, iF_drift, if_Entry, iF_exit, iF_launch, iF_ff, iF_fr, iF_awd, iF_mr;
    [SerializeField] TMP_Text charNameUI, charAgeUI, charCarUI;
    [SerializeField] TMP_Text message;

    List<string[]> table = new List<string[]>();

    private void Awake()
    {
        string _jsonID = userID + "_" + charEntryID;
        SaveSystem saveSystem = new SaveSystem();
        if(saveSystem.LoadPJSheet(_jsonID) != null)
        {
            SceneChanger.ChangeScene(1);
        }

        iF_CharName.onValueChanged.AddListener(EnterCharName);
        iF_CharAge.onValueChanged.AddListener(EnterCharAge);
        iF_grip.onValueChanged.AddListener(EnterGrip);
        iF_drift.onValueChanged.AddListener(EnterDrift);
        if_Entry.onValueChanged.AddListener(EnterEntry);
        iF_exit.onValueChanged.AddListener(EnterExit);
        iF_launch.onValueChanged.AddListener(EnterLaunch);
        iF_ff.onValueChanged.AddListener(EnterFWD);
        iF_fr.onValueChanged.AddListener(EnterFR);
        iF_awd.onValueChanged.AddListener(EnterAWD);
        iF_mr.onValueChanged.AddListener(EnterMR);
    }

    void EnterCharName(string val)
    { charName = val; MenuSFX.instance.Move();
        charNameUI.text = "Name: " + val;
    }
    void EnterCharAge(string val)
    { charAge = val; MenuSFX.instance.Move();
        charAgeUI.text = "Age: " + val;
    }
    void EnterGrip(string val)
    {
        gripSkill = val; MenuSFX.instance.Move();
    }
    void EnterDrift(string val)
    {
        driftSkill = val; MenuSFX.instance.Move();
    }
    void EnterEntry(string val)
    {
        cornerEntry = val; MenuSFX.instance.Move();
    }
    void EnterExit(string val)
    {
        cornerExit = val; MenuSFX.instance.Move();
    }
    void EnterLaunch(string val)
    {
        launch = val; MenuSFX.instance.Move();
    }

    void EnterFWD(string val)
    {
        fwdSkill = val; MenuSFX.instance.Move();
    }

    void EnterFR(string val)
    {
        rwdSkill = val; MenuSFX.instance.Move();
    }

    void EnterAWD(string val)
    {
        awdSkill = val; MenuSFX.instance.Move();
    }

    void EnterMR(string val)
    {
        rearEngSkill = val; MenuSFX.instance.Move();
    }



    public void ChooseCarID(int id)
    {
        charCarID = id.ToString(); MenuSFX.instance.Move();
    }

    public void Save()
    {
        if ((charName == "") || (charAge == "") || (charCarID == ""))
        {
            //ChangeTextMessage("Please fill all the input fields", Color.red);
            MenuSFX.instance.Error();
            return;
        }
        jsonID = userID + "_" + charEntryID;
        SaveSystem saveSystem = new SaveSystem();
        CarSheetStruct pJSheetStruct = new CarSheetStruct(charName, charAge, charCarID);
        saveSystem.SavePjSheet(pJSheetStruct, jsonID);
        //ChangeTextMessage("Car successfully saved", Color.black);
        MenuSFX.instance.Purchase();
    }
    //public void ChangeTextMessage(string text, Color color)
    //{
    //    message.text = text;
    //    message.color = color;
    //}

    string[] buildTable(string key, string data)
    {
        string[] fila = new string[2];

        fila[0] = key;
        fila[1] = data;

        return fila;
    }

    public void CreateCSVList()
    {
        table.Add(buildTable("Grip", gripSkill));
        table.Add(buildTable("Drift", driftSkill));
        table.Add(buildTable("Entry", cornerEntry));
        table.Add(buildTable("Exit", cornerExit));
        table.Add(buildTable("Launch", launch));
        table.Add(buildTable("FF", fwdSkill));
        table.Add(buildTable("FR", rwdSkill));
        table.Add(buildTable("AWD", awdSkill));
        table.Add(buildTable("MR", rearEngSkill));

        CSVHandler csvH = new CSVHandler("CharacterData");
        csvH.WriteToCSV(table);
    }
}
