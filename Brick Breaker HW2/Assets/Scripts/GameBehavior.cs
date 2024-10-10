using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameBehavior : MonoBehaviour
{
    public static GameBehavior Instance { get; private set; }

    private int _score;

    public int Score
    {
        get { return _score; }
        set
        {
            _score = value;
            UpdateScoreUI();  
        }
    }

    [SerializeField] private TextMeshProUGUI _scoreTextUI;
    [SerializeField] private GameObject pauseMenuUI;

    public enum GameState
    {
        Playing,
        Paused
    }

    public GameState gameState = GameState.Playing;

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

    private void UpdateScoreUI()
    {
        if (_scoreTextUI != null)
        {
            _scoreTextUI.text = "Score: " + _score;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (gameState == GameState.Playing)
            {
                PauseGame();
            }
            else if (gameState == GameState.Paused)
            {
                ResumeGame();
            }
        }
    }

    void PauseGame()
    {
        gameState = GameState.Paused;
        Time.timeScale = 0;
        pauseMenuUI.SetActive(true);
    }

    void ResumeGame()
    {
        gameState = GameState.Playing;
        Time.timeScale = 1;
        pauseMenuUI.SetActive(false);
    }
}