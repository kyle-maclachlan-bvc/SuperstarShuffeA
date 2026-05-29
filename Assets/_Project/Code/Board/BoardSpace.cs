using UnityEngine;
using System.Collections.Generic;

public class BoardSpace : MonoBehaviour
{
    [SerializeField] private int spaceIndex;
    [SerializeField] private List<BoardSpace> nextSpaces = new();
    
    public int SpaceIndex => spaceIndex;
    public List<BoardSpace> NextSpaces => nextSpaces;
    
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.goldenRod;
        Gizmos.DrawSphere(transform.position, 0.25f);
    }
}
