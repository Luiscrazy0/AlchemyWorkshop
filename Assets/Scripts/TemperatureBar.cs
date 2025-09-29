using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class TemperatureBar : MonoBehaviour
{
    public static float temperature = 33f;
    public float highestPos;
    public float lowestPos;
    
    // Start is called before the first frame update
    void Start()
    {
        temperature = 33f;

    }

    // Update is called once per frame
    void Update()
    {
        UIOfTemperature();
        AutoCooling();
        Heating();
        Cooling();
    }

    public void AutoCooling()
    {
        if (temperature <= 100 && temperature > 0)
        {
            temperature -= 4 * Time.deltaTime;


        }
        else if (temperature > 100)
        {
            GameController.Instance.SetState(GameController.GameState.Victory);
            Debug.Log("温度达到100，开始结算");
        }
        else
        {
            GameController.Instance.SetState(GameController.GameState.GameOver);
            Debug.Log("温度为0，游戏失败");
        }
            
    }

    public void Heating ()
    {
       if( Input.GetKey(KeyCode.Space))
        {
            temperature += 40 *Time.deltaTime;
        }
    }
    public void Cooling()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            temperature -= 20 * Time.deltaTime;
        }
    }

    public void UIOfTemperature()
    {
        float normalized = Mathf.InverseLerp(0f, 100f, temperature);
        float posY = Mathf.Lerp(lowestPos, highestPos, normalized);
        GetComponent<RectTransform>().anchoredPosition = new Vector2(0f, posY);
    }
}
