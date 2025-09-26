using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelButton : MonoBehaviour
{
    public LevelBase levelData;
    public TMP_Text levelText;
    public Button levelButton; 

    // Start is called before the first frame update
    void Start()
    {
        levelButton = GetComponent<Button>();
        levelButton.onClick.AddListener(Click);
        levelText = GetComponentInChildren<TMP_Text>();
        levelText.text = levelData.levelName;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Click()
    {
        Debug.Log("click");
        GameController.selectedLevel = levelData;
        SceneManager.LoadScene("GameScene");
    }
}
