using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController Instance;
    public static LevelBase selectedLevel;

    public enum GameState
    {
        Playing,
        Paused,
        GameOver,
        Victory
    }

    public GameState CurrentState {  get; private set; } = GameState.Playing;

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
        Time.timeScale = Mathf.Lerp(1f,0f, 10*Time.deltaTime);
        SceneManager.LoadScene(0);
        // 弹出失败UI
        //UIManager.Instance.ShowGameOverUI();
    }

    private void OnVictory()
    {
        
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
