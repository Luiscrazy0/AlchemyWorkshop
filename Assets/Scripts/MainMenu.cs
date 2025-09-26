using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu: MonoBehaviour
{
    public bool canLoad = false;//�ж��Ƿ��������¼
    
    public Button playButton;
    public Button continueButton;//ֱ�Ӵ���һ�ε����һ�ؿ�ʼ
    public Button quitButton;//��ȡ������ʼ���水ť

    public Button backButton;
    public TMP_Text moneyNum;

    public GameObject mainPanel;
    public GameObject levelPanel;//��ȡ����panel�����л����ؿ�ѡ�����
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
        Debug.Log("��Ϸ���˳�");
        Application.Quit();
        
    }
    public virtual void LoadGame()
    {

    }
}
