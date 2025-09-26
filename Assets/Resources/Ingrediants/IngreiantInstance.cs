using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class IngreiantInstance : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public IngrediantsBase ingrediantData;  // 绑定的材料数据 (ScriptableObject)
    private Transform originalParent;
    private CanvasGroup canvasGroup;
   

    private void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        originalParent = transform.parent;
        transform.SetParent(transform.root); // 提到最上层Canvas，避免被遮挡
        canvasGroup.blocksRaycasts = false;  // 允许检测到Drop区域
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position; // 跟随鼠标
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.SetParent(originalParent);
        canvasGroup.blocksRaycasts = true;
    }
}
