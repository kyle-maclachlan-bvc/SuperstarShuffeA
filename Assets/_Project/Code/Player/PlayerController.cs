using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool ControlsEnabled { get; private set; }

    public void EnableControls()
    {
        ControlsEnabled = true;
    }
    
    public void DisableControls()
    {
        ControlsEnabled = false;
    }
}
