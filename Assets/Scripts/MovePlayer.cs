using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    [SerializeField] private UIController _uiController;
    [SerializeField] private GameObject _snakeSegmentPrefab;
    private List<Transform> _segments;
    
    private Vector3 _moveDirection = Vector3.left;

    private void Start()
    {
        _segments = new List<Transform>();
        _segments.Add(gameObject.transform);
    }

    private void Update()
    {
        //change direction
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            _moveDirection = Vector3.right;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            _moveDirection = Vector3.left;
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            _moveDirection = Vector3.up;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            _moveDirection = Vector3.down;
        }
    }

    private void FixedUpdate()
    {
        for (int i = _segments.Count - 1; i > 0; i--)
        {
            _segments[i].position = _segments[i - 1].position;
        }
        
        transform.position = new Vector3(
            Mathf.Round(transform.position.x) + _moveDirection.x,
            Mathf.Round(transform.position.y) + _moveDirection.y,
            0
        );
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Food"))
        {
            GameManager.Instance.Score++;
            _uiController.UpdateScoreText(GameManager.Instance.Score);
            GrowSnake();
            Destroy(other.gameObject);
            
        }

        if (other.CompareTag("Border") || other.CompareTag("Snake"))
        {
            GameManager.Instance.GameOver = true;
            Destroy(gameObject);
        }
    }

    private void GrowSnake()
    {
        GameObject snakeSegment = Instantiate(_snakeSegmentPrefab);
        snakeSegment.transform.position = _segments[_segments.Count - 1].position;
        
        _segments.Add(snakeSegment.transform);
    }
}
