using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private BoardSpace currentSpace;
    [SerializeField] private MovementState movementState = MovementState.Idle;

    private int remainingSpaces;
    private BoardSpace pendingIntersection;
    
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
}
