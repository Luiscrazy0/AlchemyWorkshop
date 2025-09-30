using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "potion", menuName = "AmyAsset/potion", order =1)]
public class PotionBase : ScriptableObject
{
    public string potionName;
    public Sprite icon;
    public int potionLevel;
    public int baseQuality;

}
