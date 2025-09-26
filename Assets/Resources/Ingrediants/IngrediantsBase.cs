using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ingredient", menuName = "AmyAsset/ingredient",order = 0)]
public class IngrediantsBase : ScriptableObject
{
    public string ingredientName;
    public Sprite icon;
    public int baseQuality;
    public int cost;

    public int fire;
    public int water;
    public int wood;
    public int metal;
    public int earth;
   
    // 返回这个材料的“属性值 + 对应颜色”
    public (int value, Color color,string type) GetElementInfo()
    {
        if (fire > 0) return (fire, Color.red,"fire");
        if (water > 0) return (water, Color.blue,"water");
        if (wood > 0) return (wood, new Color(0f, 0.8f, 0f),"wood"); // 绿色
        if (metal > 0) return (metal, Color.yellow,"metal");
        if (earth > 0) return (earth, new Color(0.6f, 0.4f, 0.2f),"earth"); // 棕色

        return (0, Color.white,"none"); // 默认
    }


}
