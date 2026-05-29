using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Game State")]
    [SerializeField] private GameState currentGameState;
    
    public GameState CurrentGameState => currentGameState;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        ChangeGameState(GameState.PlayerTurn);
    }

    public void ChangeGameState(GameState newState)
    {
        currentGameState = newState;
        GameEvents.OnGameStateChange?.Invoke(newState);
        Debug.Log(currentGameState.ToString());
    }
}
