using UnityEngine;

public class PlayerTurnState : MonoBehaviour
{
    [SerializeField] private PlayerState currentState;

    public PlayerState CurrentState
    {
        get => currentState;
        set => currentState = value;
    }
}
