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
        
        PlayerMovement currentPlayer = players[currentPlayerIndex];
        PlayerController currentController = playerControllers[currentPlayerIndex];

        if (currentPlayer.IsWaitingForDirection())
        {
            HandleIntersectionInput(
                currentPlayer, currentController);

            return;
        }
        
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

            players[currentPlayerIndex].StartMovingSpaces(rollValue);
        }

        private void HandleIntersectionInput(PlayerMovement player, PlayerController controller)
        {
            if (controller.SelectRightPressed()
                &&
                player.IsDirectionAvailable(
                    PathDirection.Right))
            {
                player.SelectDirection(
                    PathDirection.Right);
            }

            if (controller.SelectDownPressed()
                &&
                player.IsDirectionAvailable(
                    PathDirection.Down))
            {
                player.SelectDirection(
                    PathDirection.Down);
            }

            if (controller.SelectLeftPressed()
                &&
                player.IsDirectionAvailable(
                    PathDirection.Left))
            {
                player.SelectDirection(
                    PathDirection.Left);
            }

            if (controller.SelectUpPressed()
                &&
                player.IsDirectionAvailable(
                    PathDirection.Up))
            {
                player.SelectDirection(
                    PathDirection.Up);
            }

            if (controller.ConfirmPressed())
            {
                player.ConfirmDirection();
            }
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
