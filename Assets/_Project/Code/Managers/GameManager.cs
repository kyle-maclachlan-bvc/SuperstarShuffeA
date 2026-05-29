using UnityEngine;
using UnityEngine.Rendering;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Game State")]
    [SerializeField] private GameState currentGameState;
    
    public GameState CurrentGameState => currentGameState;

    [Header("Match Settings")]
    [SerializeField] private int currentTurn = 1;
    [SerializeField] private int maxTurns = 10;
    
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

    public void RoundCompleted()
    {
        Debug.Log($"Turn {currentTurn} completed");

        if (currentTurn >= maxTurns)
        {
            Debug.Log($"Game Over");
            
            ChangeGameState(GameState.Results);

            return;
        }

        currentTurn++;
        
        ChangeGameState(GameState.MinigameTutorial);
    }
}
