using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/Game State SO", fileName = "GameStateSO")]
public class GameStateSO : ScriptableObject
{
    public State currentState = State.None;

    public enum State
    {
        None,
        GamePrepare,
        GameStart,
        GameNextLevel,
        GameRestartLevel,
        GameOver,
        GameEnd
    }
}
