using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    public GameObject gameOverPanel;
    public GameObject victoryPanel;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject); // 已经有了，就摧毁新生成的
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void ShowGameOverUI()
    {
        gameOverPanel.SetActive(true);
    }

    public void ShowVictoryUI()
    {
        victoryPanel.SetActive(true);
    }
}
