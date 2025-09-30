using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    private LevelBase level;
    public GameObject ingredientIconPrefab;
    public Transform ingredientIconParent;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("levelManagerStart");
        GameController.Instance.SetState(GameController.GameState.Playing);
        
        level = GameController.selectedLevel;
        
        GenerateMaterials();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GenerateMaterials()//将材料按顺序排列在交互界面上
    {
        foreach(var ingredient in level.availabelIngredients)
        {
            
            GameObject ingredientBtn = Instantiate(ingredientIconPrefab, ingredientIconParent);

            ingredientBtn.GetComponentInChildren<TMP_Text>().text = ingredient.ingredientName;

            ingredientBtn.GetComponent<Image>().sprite = ingredient.icon;

            ingredientBtn.GetComponent<IngreiantInstance>().ingrediantData = ingredient;


        }

    }
}
