using UnityEngine;

public class AIState : MonoBehaviour
{
    public enum State
    {
        Idle,
        AttackTower,
        AttackEnemy
    }

    public State currentState = State.Idle;
}
