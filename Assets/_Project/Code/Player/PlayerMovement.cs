using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private int currentSpaceIndex = 0;

    public int CurrentSpaceIndex
    {
        get => currentSpaceIndex;
        set => currentSpaceIndex = value;
    }

    public void MoveSpaces(int spaces)
    {
        currentSpaceIndex += spaces;
        
        BoardSpace targetSpace =
            BoardManager.Instance.GetSpace(currentSpaceIndex);

        if (targetSpace == null)
            return;

        transform.position = targetSpace.transform.position;
        
        Debug.Log($"Moved to Spcae {currentSpaceIndex}");
    }
}
