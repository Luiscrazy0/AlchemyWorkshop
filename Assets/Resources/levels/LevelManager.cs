using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    private LevelBase level;
    private PotionManager potionManager;
    public GameObject ingredientIconPrefab;
    public Transform ingredientIconParent;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("levelManagerStart");
        GameAssets.GameFail = false;
        potionManager = FindObjectOfType<PotionManager>();
        level = GameController.selectedLevel;
        if (potionManager != null && level != null)
            potionManager.currentPotionConfig = level.targetPotion;
        GenerateMaterials();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GenerateMaterials()//�����ϰ�˳�������ڽ���������
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
