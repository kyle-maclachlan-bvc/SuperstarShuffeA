using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Vector3 cameraOffset = new Vector3(0f, 5f, -5f);

    public void FocusPlayer(Transform player)
    {
        //Debug.Log($"Focusing on {player.name}");
        
        transform.position =
            player.position + cameraOffset;

        transform.LookAt(player);
    }
}
