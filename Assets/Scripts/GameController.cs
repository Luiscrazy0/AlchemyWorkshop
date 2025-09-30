using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController Instance;
    public static LevelBase selectedLevel;
    public PotController pot;

    public enum GameState
    {
        Playing,
        Paused,
        GameOver,
        Victory
    }

    public GameState CurrentState {  get; private set; } = GameState.Playing;

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // 尝试在新场景里找到 PotController
        pot = FindObjectOfType<PotController>();
    }
    private void Awake()

    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
        CurrentState = GameState.Playing;
    }
    private void Update()
    {
        if (CurrentState == GameState.Playing && Input.GetKeyDown(KeyCode.Escape))
        {
            SetState(GameState.Paused);
        }
        else if (CurrentState == GameState.Paused && Input.GetKeyDown(KeyCode.Escape))
        {
            Resume();
            SetState(GameState.Playing);
        }
    }

    public void SetState(GameState newState)
    {
        if (CurrentState == newState) return;
        CurrentState = newState;
        Debug.Log("Game State changed to:" + newState);

        switch (newState)
        {
            case GameState.Playing:

                break;
            case GameState.Paused:
                OnPaused();
                break;
            case GameState.GameOver:
                OnGameOver();
                break;
            case GameState.Victory:
                OnVictory(); 
                break;

        }

    }
    private void OnGameOver()
    {
        // 停止时间流逝
        
        SceneManager.LoadScene(0);
        // 弹出失败UI
        //UIManager.Instance.ShowGameOverUI();
    }

    private void OnVictory()
    {
        int grade = Grader.CalculateGrade(pot.ingredients);
        Debug.Log("炼丹分数为:" + grade);
        
        //UIManager.Instance.ShowVictoryUI();
    }

    private void OnPaused()
    {
        Time.timeScale = 0f;
        //UIManager.Instance.ShowPausedUI();
    }
    public void Resume()
    {
        Time.timeScale = 1f;
        SetState(GameState.Playing);
    }
}
