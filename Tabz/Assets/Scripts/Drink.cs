using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Drink",menuName ="Bar Menu/Drinks")]
public class Drink : ScriptableObject {

    public new string name;
    public float price;
    public Alcohol[] alcohol;
    
    public class Alcohol {
        public Liquors liquor;
        public float ounces;

    }

}
