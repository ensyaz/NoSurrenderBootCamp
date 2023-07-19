using UnityEngine;

public class TurretState : MonoBehaviour
{
    protected enum State
    {
        None,
        Search,
        Attack
    }

    [SerializeField] protected State currentState = State.Search;
}
