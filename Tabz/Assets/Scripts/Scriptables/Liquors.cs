using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Liquor", menuName = "Bar Menu/Liquors")]
public class Liquors : ScriptableObject {

    public string liquorName;
    public float abv;
}
