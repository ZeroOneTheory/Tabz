using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Drink",menuName ="Bar/Drinks")]
public class Drink : ScriptableObject {

    public string drinkName;
    public enum GlassTypes { rocks,shot,highball,Martini,Wine,Sniffter,Hurricane,Pint};
    public GlassTypes glassType;

    // Meth: Calculate Abv
    // Meth: Calculate total Volume

}
