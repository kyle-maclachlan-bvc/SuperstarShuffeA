using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerController Controller { get; private set; }
    public PlayerMovement Movement { get;  private set; }
    public PlayerCurrency Currency { get;  private set; }
    public PlayerTurnState TurnState { get;  private set; }

    private void Awake()
    {
        Controller = GetComponent<PlayerController>();
        Movement = GetComponent<PlayerMovement>();
        Currency = GetComponent<PlayerCurrency>();
        TurnState = GetComponent<PlayerTurnState>();
    }
}
