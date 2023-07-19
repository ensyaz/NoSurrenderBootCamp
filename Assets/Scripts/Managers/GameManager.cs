using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameModeSO gameModeSO;
    [SerializeField] private GameStateSO gameStateSO;

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

    private void Start()
    {
        gameModeSO.RaiseOnGamePrepare();
    }

    private void OnGamePrepare()
    {
        gameStateSO.currentState = GameStateSO.State.GamePrepare;
    }

    private void OnGameStart()
    {
        gameStateSO.currentState = GameStateSO.State.GameStart;
    }

     private void OnGameNextLevel()
    {
        gameStateSO.currentState = GameStateSO.State.GameNextLevel;
    }

    private void OnGameRestartLevel()
    {
        gameStateSO.currentState = GameStateSO.State.GameRestartLevel;
    }

    private void OnGameOver()
    {
        gameStateSO.currentState = GameStateSO.State.GameOver;
    }

    private void OnGameEnd()
    {
        gameStateSO.currentState = GameStateSO.State.GameEnd;
    }
}
