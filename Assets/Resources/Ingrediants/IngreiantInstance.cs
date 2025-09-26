using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class IngreiantInstance : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public IngrediantsBase ingrediantData;  // �󶨵Ĳ������� (ScriptableObject)
    private Transform originalParent;
    private CanvasGroup canvasGroup;
   

    private void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        originalParent = transform.parent;
        transform.SetParent(transform.root); // �ᵽ���ϲ�Canvas�����ⱻ�ڵ�
        canvasGroup.blocksRaycasts = false;  // �����⵽Drop����
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position; // �������
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.SetParent(originalParent);
        canvasGroup.blocksRaycasts = true;
    }
}
