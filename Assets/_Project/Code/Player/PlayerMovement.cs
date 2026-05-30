using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private BoardSpace currentSpace;
    [SerializeField] private MovementState movementState = MovementState.Idle;

    private int remainingSpaces;
    private BoardSpace pendingIntersection;

    private PathDirection selectedDirection;
    private bool waitingForConfirmation;

    public bool IsWaitingForDirection()
    {
        return movementState == MovementState.WaitingForDirection;
    }
    
    public BoardSpace CurrentSpace
    {
        get => currentSpace;
        set => currentSpace = value;
    }

    public MovementState CurrentMovementState => movementState;

    private void Start()
    {
        if (currentSpace != null)
        {
            transform.position = currentSpace.transform.position;
        }
    }

    private void Update()
    {
        if (movementState != MovementState.WaitingForDirection)
            return;

        HandleIntersectionInput();
    }

    public void StartMovingSpaces(int spaces)
    {
        movementState = MovementState.Moving;

        remainingSpaces = spaces;

        ContinueMovement();
    }

    public void ContinueMovement()
    {
        BoardSpace targetSpace = currentSpace;

        while (remainingSpaces > 0)
        {
            if (targetSpace.NextSpaces.Count == 0)
            {
                Debug.LogWarning(
                    $"Space {targetSpace.SpaceIndex} has no Next Spaces assigned");

                break;
            }

            targetSpace = targetSpace.NextSpaces[0];

            remainingSpaces--;

            currentSpace = targetSpace;

            transform.position =
                currentSpace.transform.position;

            Debug.Log(
                $"Moved to Space {currentSpace.SpaceIndex}");

            if (currentSpace.SpaceType ==
                SpaceType.Intersection)
            {
                pendingIntersection = currentSpace;

                movementState =
                    MovementState.WaitingForDirection;

                Debug.Log(
                    $"Reached Intersection {currentSpace.SpaceIndex}");

                Debug.Log(
                    $"Remaining Spaces: {remainingSpaces}");

                return;
            }
        }

        movementState = MovementState.Idle;
    }

    private void HandleIntersectionInput()
    {
        if (Keyboard.current.rightArrowKey.wasPressedThisFrame)
        {
            selectedDirection =
                pendingIntersection.OptionOneDirection;

            Debug.Log(
                $"Selected {selectedDirection}");

            waitingForConfirmation = true;
        }

        if (Keyboard.current.downArrowKey.wasPressedThisFrame)
        {
            selectedDirection =
                pendingIntersection.OptionTwoDirection;

            Debug.Log(
                $"Selected {selectedDirection}");

            waitingForConfirmation = true;
        }

        if (waitingForConfirmation &&
            Keyboard.current.enterKey.wasPressedThisFrame)
        {
            ConfirmDirection();
        }
    }

    public void SelectDirection(PathDirection direction)
    {
        selectedDirection = direction;
        
        Debug.Log($"Selected Direction: {selectedDirection}");
    }
    
    public bool IsDirectionAvailable(
        PathDirection direction)
    {
        if (pendingIntersection == null)
            return false;

        return direction ==
               pendingIntersection.OptionOneDirection
               ||
               direction ==
               pendingIntersection.OptionTwoDirection;
    }
    
    public void ConfirmDirection()
    {
        Debug.Log(
            $"Confirmed {selectedDirection}");

        if (selectedDirection ==
            pendingIntersection.OptionOneDirection)
        {
            currentSpace =
                pendingIntersection.NextSpaces[0];
        }
        else
        {
            currentSpace =
                pendingIntersection.NextSpaces[1];
        }

        transform.position =
            currentSpace.transform.position;

        movementState =
            MovementState.Moving;

        waitingForConfirmation = false;

        ContinueMovement();
    }
}
