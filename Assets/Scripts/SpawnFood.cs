using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using Random = UnityEngine.Random;

public class SpawnFood : MonoBehaviour
{
    [SerializeField] private GameObject _foodPrefab;
    [SerializeField] private BoxCollider2D _gridArea;
    private float _xPos;
    private float _yPos;
    private int _currScore;
    
    private void Start()
    {
        SpawnFoodItem();
    }

    private void Update()
    {
        if (CheckScore())
        {
            SpawnFoodItem();
        }
    }

    private void SpawnFoodItem()
    {
        _currScore = GameManager.Instance.Score;
        
        Bounds gridBounds = _gridArea.bounds;
        _xPos = Random.Range(gridBounds.min.x, gridBounds.max.x);
        _yPos = Random.Range(gridBounds.min.y, gridBounds.max.y);
        Mathf.Round(_xPos);
        Mathf.Round(_yPos);
        
        GameObject clone = Instantiate(_foodPrefab);
        clone.transform.position = new Vector3(_xPos, _yPos, 0);
    }

    private bool CheckScore()
    {
        if (_currScore < GameManager.Instance.Score)
        {
            return true;
        }
        return false;
    }
}
