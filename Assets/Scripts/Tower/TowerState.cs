using UnityEngine;

public class TowerState : MonoBehaviour
{
    protected enum State
    {
        None,
        Search,
        Attack
    }

    [SerializeField] protected State currentState = State.Search;
}
