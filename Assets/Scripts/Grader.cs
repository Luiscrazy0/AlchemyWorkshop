using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using Unity.VisualScripting;
using UnityEngine;

public class Grader : MonoBehaviour
{
    

    public static int CalculateGrade(List<RefinedElement> refinedElements)
    {
        if (refinedElements == null || refinedElements.Count == 0)
            return 0;

        refinedElements.Sort((a,b) => a.refine.CompareTo(b.refine)) ;


        int grade = 0;
        bool isMiddlePass =true;
        RefinedElement current =null;
        foreach (var elem in refinedElements)
        {
            Debug.Log("材料炼化度" + elem.refine);
            if (elem.refine <= 33)
            {
                grade += elem.value;
            }else if(elem.refine >33 && elem.refine <= 66)
            {
                if (!isMiddlePass)
                {
                    current = null;
                }//在中间层出现过相克就会全部跳过不加分。

                if (current == null)
                {
                    current = new RefinedElement { type = elem.type, value = elem.value, refine = elem.refine };
                    Debug.Log("已对current赋值");
                        
                }
                else
                {
                    
                    // 相生？
                    if (IsGenerating(current.type, elem.type))
                    {
                        current.type = elem.type;
                        current.value = (current.value + elem.value) * 4;
                    }
                    // 相克？
                    else if (IsOvercoming(current.type, elem.type))
                    {
                      isMiddlePass =false  ; // 爆丹，区间分数清零
                    }
                    else
                    {
                        // 不相关，就叠加
                        current.value += elem.value;
                    }
                    
                }
            }else // 67-100 顶层
            {
                if (!isMiddlePass)
                {
                    current = null;
                    isMiddlePass = true;
                }//在中间层出现过相克就会全部跳过不加分。
                if (current == null)
                {
                    current = new RefinedElement { type = elem.type, value = elem.value, refine = elem.refine };
                }
                else
                {
                    if (IsGenerating(current.type, elem.type))
                    {
                        current.type = elem.type;
                        current.value = (current.value + elem.value) * 2;
                    }
                    else if (IsOvercoming(current.type, elem.type))
                    {
                        current.value = Mathf.Abs(current.value - elem.value);
                    }
                    else
                    {
                        current.value += elem.value;
                    }
                }
            }
        }
        bool test1 = (current != null);
        if(current != null)
        {
            grade += current.value;
            
        }
        Debug.Log("已加current到grade上" + test1);
        return grade;
    }

    private static bool IsGenerating(string a, string b)
    {
        
        return (a == "wood" && b == "fire") ||
               (a == "fire" && b == "earth") ||
               (a == "earth" && b == "metal") ||
               (a == "metal" && b == "water") ||
               (a == "water" && b == "wood");
    }

    private static bool IsOvercoming(string a, string b)
    {
        
        
            return (a == "wood" && b == "earth") ||
                   (a == "earth" && b == "water") ||
                   (a == "water" && b == "fire") ||
                   (a == "fire" && b == "metal") ||
                   (a == "metal" && b == "wood");
        

            
    }

}
