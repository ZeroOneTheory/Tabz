using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Drink",menuName ="Bar/Drinks")]
public class Drink : ScriptableObject {

    public string drinkName;
    public enum GlassTypes { rocks,shot,highball};
    public GlassTypes glassType;

    public Drink(string name) {
        drinkName = name;
    }

}
