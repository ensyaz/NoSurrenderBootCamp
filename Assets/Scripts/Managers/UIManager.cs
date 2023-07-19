using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameModeSO gameModeSO;

    private void OnEnable()
    {
        gameModeSO.OnGamePrepare += OnGamePrepare;
        gameModeSO.OnGameStart += OnGameStart;
        gameModeSO.OnGameOver += OnGameNextLevel;
        gameModeSO.OnGameEnd += OnGameRestartLevel;
        gameModeSO.OnGameOver += OnGameOver;
        gameModeSO.OnGameEnd += OnGameEnd;
    }

    private void OnDisable()
    {
        gameModeSO.OnGamePrepare -= OnGamePrepare;
        gameModeSO.OnGameStart -= OnGameStart;
        gameModeSO.OnGameOver -= OnGameNextLevel;
        gameModeSO.OnGameEnd -= OnGameRestartLevel;
        gameModeSO.OnGameOver -= OnGameOver;
        gameModeSO.OnGameEnd -= OnGameEnd;
    }

    private void OnGamePrepare()
    {
    }

    private void OnGameStart()
    {
    }

    private void OnGameNextLevel()
    {
    }

    private void OnGameRestartLevel()
    {
    }

    private void OnGameOver()
    {
    }

    private void OnGameEnd()
    {
    }
}
