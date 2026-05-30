using UnityEngine;
using System.Collections.Generic;

public class BoardSpace : MonoBehaviour
{
    [SerializeField] private int spaceIndex;
    [SerializeField] private SpaceType spaceType;
    [SerializeField] private List<BoardSpace> nextSpaces = new();

    [SerializeField] private PathDirection optionOneDirection;
    [SerializeField] private PathDirection optionTwoDirection;
    
    public PathDirection OptionOneDirection => optionOneDirection;
    public PathDirection OptionTwoDirection => optionTwoDirection;
    
    public int SpaceIndex => spaceIndex;
    public SpaceType SpaceType => spaceType;
    public List<BoardSpace> NextSpaces => nextSpaces;
    
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.goldenRod;
        Gizmos.DrawSphere(transform.position, 0.25f);
    }
}
