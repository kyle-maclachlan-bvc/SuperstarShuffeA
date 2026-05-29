using UnityEngine;
using UnityEngine.InputSystem;

public class TurnManager : MonoBehaviour
{
    /*private int currentPlayerIndex = 0;

    private void OnEnable()
    {
        GameEvents.OnGameStateChange += HandleStateChanged;
    }

    private void OnDisable()
    {
        GameEvents.OnGameStateChange -= HandleStateChanged;
    }

    private void HandleStateChanged(GameState state)
    {
        if (state == GameState.PlayerTurn)
            BeginTurn();
    }

    private void BeginTurn()
    {
        Debug.Log($"Player {currentPlayerIndex + 1} Turn");
    }*/

    [SerializeField] private DiceBlock diceBlock;
    [SerializeField] private PlayerMovement playerMovement;

    private void Update()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            RollDice();
        }

        void RollDice()
        {
            int rollValue = diceBlock.Roll();

            Debug.Log($"Rolled: {rollValue}");

            playerMovement.MoveSpaces(rollValue);
        }
    }
}
