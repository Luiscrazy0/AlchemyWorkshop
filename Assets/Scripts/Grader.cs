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
            Debug.Log("����������" + elem.refine);
            if (elem.refine <= 33)
            {
                grade += elem.value;
            }else if(elem.refine >33 && elem.refine <= 66)
            {
                if (!isMiddlePass)
                {
                    current = null;
                }//���м����ֹ���˾ͻ�ȫ���������ӷ֡�

                if (current == null)
                {
                    current = new RefinedElement { type = elem.type, value = elem.value, refine = elem.refine };
                    Debug.Log("�Ѷ�current��ֵ");
                        
                }
                else
                {
                    
                    // ������
                    if (IsGenerating(current.type, elem.type))
                    {
                        current.type = elem.type;
                        current.value = (current.value + elem.value) * 4;
                    }
                    // ��ˣ�
                    else if (IsOvercoming(current.type, elem.type))
                    {
                      isMiddlePass =false  ; // �����������������
                    }
                    else
                    {
                        // ����أ��͵���
                        current.value += elem.value;
                    }
                    
                }
            }else // 67-100 ����
            {
                if (!isMiddlePass)
                {
                    current = null;
                    isMiddlePass = true;
                }//���м����ֹ���˾ͻ�ȫ���������ӷ֡�
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
        Debug.Log("�Ѽ�current��grade��" + test1);
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
