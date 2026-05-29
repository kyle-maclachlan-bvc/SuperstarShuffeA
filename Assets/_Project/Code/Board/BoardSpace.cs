using UnityEngine;

public class BoardSpace : MonoBehaviour
{
    [SerializeField] private int spaceIndex;
    
    public int SpaceIndex => spaceIndex;
    
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.goldenRod;
        Gizmos.DrawSphere(transform.position, 0.25f);
    }
}
