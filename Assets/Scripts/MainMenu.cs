using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu: MonoBehaviour
{
    
    
    public Button playButton;
    public Button potionStorageButton;//
    public Button quitButton;//��ȡ������ʼ���水ť

   
    public TMP_Text moneyNum;

    public GameObject mainPanel;
    public GameObject levelPanel;
    public GameObject storagePanel;//��ȡ����panel�����л����ؿ�ѡ�����
    private void Start()
    {
        playButton.onClick.AddListener(OpenLevelSelect);
        quitButton.onClick.AddListener(QuitGame);
        potionStorageButton.onClick.AddListener(OpenStoragePanel);
    }
    private void Update()
    {
        //if (true)
        //{
        //    potionStorageButton.interactable = true;
        //}
        //else
        //{
        //    potionStorageButton.interactable = false;
            
        //}
        
        moneyNum.text = PlayerData.Instance.money.ToString();    
        
    }
    public void OpenLevelSelect()
    {
        mainPanel.SetActive(false);
        levelPanel.SetActive(true);
        storagePanel.SetActive(false);

    }
    public void OpenMainPanel()
    {
        mainPanel.SetActive(true);
        levelPanel.SetActive(false);
        storagePanel.SetActive(false);
    }
    public void OpenStoragePanel()
    {
        mainPanel.SetActive(false);
        levelPanel.SetActive(false);
        storagePanel.SetActive(true);
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
    
}
