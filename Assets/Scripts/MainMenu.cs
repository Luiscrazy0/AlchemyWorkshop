using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu: MonoBehaviour
{
    public bool canLoad = false;//判断是否有游玩记录
    
    public Button playButton;
    public Button continueButton;//直接从上一次的最后一关开始
    public Button quitButton;//获取三个开始界面按钮

    public Button backButton;
    public TMP_Text moneyNum;

    public GameObject mainPanel;
    public GameObject levelPanel;//获取两个panel方便切换到关卡选择界面
    private void Start()
    {
        playButton.onClick.AddListener(OpenLevelSelect);
        quitButton.onClick.AddListener(QuitGame);
        backButton.onClick.AddListener(OpenMainPanel);
        continueButton.onClick.AddListener(LoadGame);
    }
    private void Update()
    {
        if (!canLoad)
        {
            continueButton.interactable = false;
        }
        else
        {
            continueButton.interactable = true;
            
        }
        
        moneyNum.text = PlayerData.Instance.money.ToString();    
        
    }
    public void OpenLevelSelect()
    {
        mainPanel.SetActive(false);
        levelPanel.SetActive(true);
    }
    public void OpenMainPanel()
    {
        mainPanel.SetActive(true);
        levelPanel.SetActive(false);
    }
    public void PlayGame()
    {
        SceneManager.LoadScene("GameScene");

    }
    public void QuitGame()
    {
        Debug.Log("游戏已退出");
        Application.Quit();
        
    }
    public virtual void LoadGame()
    {

    }
}
