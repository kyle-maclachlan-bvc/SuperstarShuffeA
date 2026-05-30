using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private Vector3 cameraOffset =
        new Vector3(0f, 5f, -5f);

    private Transform targetPlayer;

    public void FocusPlayer(Transform player)
    {
        targetPlayer = player;
    }

    private void LateUpdate()
    {
        if (targetPlayer == null)
            return;

        transform.position =
            targetPlayer.position + cameraOffset;

        transform.LookAt(targetPlayer);
    }
}
