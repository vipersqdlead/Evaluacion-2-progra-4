using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable] //SIEMPRE QUE QUERAMOS CONVERTIR UNA CLASE A JSON NECESITA EL ATRIBUTO SERIALIZABLE
public class CharSheet
{
    public string charName;
    public string charAge;
    public string charCarID;

    public CharSheet(CarSheetStruct pjSheetStruct)
    {
        this.charName = pjSheetStruct.charName;
        this.charAge = pjSheetStruct.charAge;
        this.charCarID = pjSheetStruct.charCarID;
    }
}

public struct CarSheetStruct
{
    public string charName;
    public string charAge;
    public string charCarID;


    public CarSheetStruct(string _charName, string _charAge, string _charCarID)
    {
        this.charName = _charName;
        this.charAge = _charAge;
        this.charCarID = _charCarID;
    }
}
