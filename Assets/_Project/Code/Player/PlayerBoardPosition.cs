using UnityEngine;

public class PlayerBoardPosition : MonoBehaviour
{
    [SerializeField] private int currentSpaceIndex = 0;

    public int CurrentSpaceIndex
    {
        get => currentSpaceIndex;
        set => currentSpaceIndex = value;
    }
}
