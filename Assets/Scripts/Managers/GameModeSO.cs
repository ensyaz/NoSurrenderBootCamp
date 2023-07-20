using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "ScriptableObject/Game Mode SO", fileName = "GameModeSO")]
public class GameModeSO : ScriptableObject
{
    public UnityAction OnGamePrepare;
    public UnityAction OnGameStart;
    public UnityAction OnGameNextLevel;
    public UnityAction OnGameRestartLevel;
    public UnityAction OnGameOver;
    public UnityAction OnGameEnd;

    public void RaiseOnGamePrepare()
    {
        OnGamePrepare?.Invoke();
        Debug.Log("RaiseOnGamePrepare");
    }

    public void RaiseOnGameStart()
    {
        OnGameStart?.Invoke();
        Debug.Log("RaiseOnGameStart");
    }

    public void RaiseOnGameNextLevel()
    {
        OnGameNextLevel?.Invoke();
        Debug.Log("RaiseOnGameNextLevel");
    }

    public void RaiseOnGameRestartLevel()
    {
        OnGameRestartLevel?.Invoke();
        Debug.Log("RaiseOnGameRestartLevel");
    }

    public void RaiseOnGameOver()
    {
        OnGameOver?.Invoke();
        Debug.Log("RaiseOnGameOver");
    }

    public void RaiseOnGameEnd()
    {
        OnGameEnd?.Invoke();
        Debug.Log("RaiseOnGameEnd");
    }
}
