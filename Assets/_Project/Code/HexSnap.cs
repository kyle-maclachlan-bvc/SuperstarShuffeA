using UnityEngine;

[ExecuteAlways]
public class HexSnap : MonoBehaviour
{
    public float radius = 2f;

    private Vector3 lastPosition;

    private void Update()
    {
        if (!Application.isPlaying)
        {
            if (transform.position != lastPosition)
            {
                SnapToGrid();
                lastPosition = transform.position;
            }
        }
    }

    private void SnapToGrid()
    {
        float xSpacing = radius * 1.5f;
        float zSpacing = Mathf.Sqrt(3f) * radius;

        Vector3 pos = transform.position;

        int col = Mathf.RoundToInt(pos.x / xSpacing);

        float offset = (col % 2 == 0) ? 0f : zSpacing / 2f;

        int row = Mathf.RoundToInt((pos.z - offset) / zSpacing);

        transform.position = new Vector3(
            col * xSpacing,
            pos.y,
            row * zSpacing + offset
        );
    }
}