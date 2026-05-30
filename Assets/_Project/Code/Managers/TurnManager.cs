using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections.Generic;

public class TurnManager : MonoBehaviour
{
    [SerializeField] private DiceBlock diceBlock;
    [SerializeField] private List<PlayerMovement> players;
    [SerializeField] private List<PlayerTurnState> playerStates;
    [SerializeField] private List<PlayerController> playerControllers;
    [SerializeField] private CameraController cameraController;
    
    private int currentPlayerIndex = 0;

    private void Start()
    {
        BeginTurn();
    }

    private void Update()
    {
        if (playerStates[currentPlayerIndex].CurrentState
            != PlayerState.TakingTurn)
            return;

        if (playerControllers[currentPlayerIndex].RollPressed())
        {
            RollDice();
        }
    }

    private void BeginTurn()
    {
        //Debug.Log("BeginTurn Called");
            
            for (int i = 0; i < playerStates.Count; i++)
            {
                playerStates[i].CurrentState =
                    PlayerState.Waiting;

                playerControllers[i].DisableControls();
            }

            playerStates[currentPlayerIndex].CurrentState =
                PlayerState.TakingTurn;
            
            playerControllers[currentPlayerIndex].EnableControls();

            cameraController.FocusPlayer(
                players[currentPlayerIndex].transform);
            
            Debug.Log(
                $"Player {currentPlayerIndex + 1} Turn Started");
        }

        
        void RollDice()
        {
            int rollValue = diceBlock.Roll();

            Debug.Log($"Rolled: {rollValue}");

            players[currentPlayerIndex].MoveSpaces(rollValue);

            EndTurn();
        }

        private void EndTurn()
        {
            playerStates[currentPlayerIndex].CurrentState =
                PlayerState.Waiting;

            currentPlayerIndex++;

            if (currentPlayerIndex >= players.Count)
            {
                currentPlayerIndex = 0;

                GameManager.Instance.RoundCompleted();

                // future
                // Start Minigame Phase
            }

            BeginTurn();
        }
}
