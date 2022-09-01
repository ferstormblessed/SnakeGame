using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] private TMP_Text _scoreUI;
    [SerializeField] private GameObject _startGameScreen;
    [SerializeField] private GameObject _gameOverScreen;
    [SerializeField] private TMP_Text _finalScoreUI;

    public void HideStartGameScreen()
    {
        _startGameScreen.SetActive(false);
    }
    
    public void ShowGameOverScreen()
    {
        _finalScoreUI.text = "Score: " + GameManager.Instance.Score;
        _gameOverScreen.SetActive(true);
    }
    
    public void UpdateScoreText(int newScore)
    {
        _scoreUI.text = "Score: " + newScore.ToString();
    }
}
