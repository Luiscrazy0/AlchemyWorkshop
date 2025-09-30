using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.ShaderGraph;
using UnityEngine;
using UnityEngine.EventSystems;

public class PotController : MonoBehaviour,IDropHandler
{
    public List<RefinedElement> ingredients = new List<RefinedElement>();
    public GameObject numPrefab;
    public Transform parentTransform;
    public void OnDrop(PointerEventData eventData)
    {
        IngreiantInstance dragged = eventData.pointerDrag.GetComponent<IngreiantInstance>();
        if (dragged != null)
        {
            Debug.Log($"炼丹炉收到材料: {dragged.ingrediantData.ingredientName}");
            // TODO: 开始炼丹逻辑
            
            SpawnNum(dragged.ingrediantData);
            Destroy(dragged.gameObject);
        }
    }
    public void SpawnNum(IngrediantsBase ingrediantData)
    {
        RectTransform container = GetComponent<RectTransform>();
        float randX = Random.value;
        

        // 算出在容器内的实际坐标
        float posX = Mathf.Lerp(0, container.rect.width-10, randX);
        

        // 生成预制体
        GameObject numObj = Instantiate(numPrefab, transform);
        RectTransform numRt = numObj.GetComponent<RectTransform>();
        numObj.GetComponent<ColorfulNum>().ingrediantData = ingrediantData;

        // 锚点固定在左下
        numRt.anchorMin = new Vector2(0, 0);
        numRt.anchorMax = new Vector2(0, 0);
        numRt.pivot = new Vector2(0.5f, 0.5f);

        // 设置随机位置
        numRt.anchoredPosition = new Vector2(posX+5f, 10f);

        Debug.Log("数字生成。");

      

       

        RefinedElement refinedElement = new();

        refinedElement.type = ingrediantData.GetElementInfo().type;
        refinedElement.value = ingrediantData.GetElementInfo().value;
        refinedElement.refine = 0;
        ingredients.Add(refinedElement);
        StartCoroutine(NumFlyUP(numRt,refinedElement,ingrediantData));
    }

    
    public IEnumerator NumFlyUP(RectTransform numRt,RefinedElement elem,IngrediantsBase ingrediantData)
    {
        
        float flySpeed = 0f;
        float posX = numRt.anchoredPosition.x;
        float flyNormorlized = 0f;
        float flyPosition = 10f;

        string raw = numRt.GetComponent<TMP_Text>().text;//数字的飞行速度和它的元素含量有关
        if (raw == null)
            Debug.Log("raw 不存在");

        float num = ingrediantData.GetElementInfo().value;
        

        Debug.Log("进入循环器");
        while (flyPosition < 220f-0.01f )
        {
            if (GameController.Instance.CurrentState == GameController.GameState.Victory)
                break;
            if (TemperatureBar.temperature < 34f)
            {
                flySpeed = 0.00f;
            } else if(TemperatureBar.temperature <67f &&TemperatureBar.temperature >= 34f)
            {
                flySpeed = 0.01f *num;
            }
            else
            {
                flySpeed = 0.02f *num;
            }
            flyNormorlized += flySpeed;
            flyPosition = Mathf.Lerp(10f, 220f, flyNormorlized);
            numRt.anchoredPosition = new Vector2(posX, flyPosition);
            elem.refine = (int)(100 * flyNormorlized);

            Debug.Log("在动");
            yield return new WaitForSeconds(0.5f);
        }
        

        Destroy(numRt.gameObject);
        ingredients.Remove(elem);
    }
}
