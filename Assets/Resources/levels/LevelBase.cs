using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "level", menuName = "AmyAsset/level",order =2)]
public class LevelBase : ScriptableObject
{
    public string levelName;
    public IngrediantsBase[] availabelIngredients;
    public PotionBase targetPotion;

}
