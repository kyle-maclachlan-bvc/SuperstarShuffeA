using UnityEngine;
using System.Collections.Generic;

public class BoardManager : MonoBehaviour
{
    public static BoardManager Instance;
    
    [SerializeField] private List<BoardSpace> boardSpaces;

    private void Awake()
    {
        Instance = this;
    }

    public BoardSpace GetSpace(int index)
    {
        if (index < 0 || index >= boardSpaces.Count)
        {
            Debug.LogWarning($"Space {index} does not exist.");
            return null;
        }
        
        return boardSpaces[index];
    }

    public int SpaceCount => boardSpaces.Count;
}
