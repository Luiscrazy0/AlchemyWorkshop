using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public static PlayerData Instance;
    public int level = 1;
    public int exp = 0;
    private int maxExp =100;
    private int expAddPerLevel = 10;
    public int money = 1000;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void GetExp(int addExp)
    {
        exp += addExp;
        while (exp > maxExp)
        {
            level++;
            exp -= maxExp;
            maxExp += expAddPerLevel;

        }
    }
    
    public void GetMoney(int addMoney)
    {
        money += addMoney;
    }
    public bool SpendMoney(int spendMoney)
    {
        if(money < spendMoney)
        {
            Debug.Log("Ç®²»¹»");
            return false;
        }
        else
        {
            money -= spendMoney;
            return true;
        }
    }

    
}
