using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager _gameManager;

    public static GameManager Instance
    {
        get => _gameManager;
        set => _gameManager = value;
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    [SerializeField] private UIController _uiController;

    private int _score = 0;

    public int Score
    {
        get => _score;
        set => _score = value;
    }

    private bool _gameOver;

    public bool GameOver
    {
        get => _gameOver;
        set
        {
            _gameOver = value;
            _uiController.ShowGameOverScreen();
        }
    }

    public void ReloadGame()
    {
        SceneManager.LoadScene("SnakeGame");
    }

    [SerializeField] private GameObject _player;

    public void StartGame()
    {
        _uiController.HideStartGameScreen();
        _player.SetActive(true);
    }
}
