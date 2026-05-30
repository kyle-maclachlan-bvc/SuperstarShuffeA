using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private int playerID;
    public bool ControlsEnabled { get; private set; }
    public int PlayerID => playerID;

    public void EnableControls()
    {
        ControlsEnabled = true;
    }
    
    public void DisableControls()
    {
        ControlsEnabled = false;
    }

    public bool RollPressed()
    {
        if (!ControlsEnabled)
            return false;

        switch (playerID)
        {
            case 1:
                return Keyboard.current.qKey.wasPressedThisFrame;
            
            case 2:
                return Keyboard.current.wKey.wasPressedThisFrame;
            
            case 3:
                return Keyboard.current.eKey.wasPressedThisFrame;
            
            case 4:
                return Keyboard.current.rKey.wasPressedThisFrame;
        }

        return false;
    }
    
    public bool SelectRightPressed()
    {
        if (!ControlsEnabled)
            return false;

        return Keyboard.current.rightArrowKey.wasPressedThisFrame;
    }

    public bool SelectDownPressed()
    {
        if (!ControlsEnabled)
            return false;

        return Keyboard.current.downArrowKey.wasPressedThisFrame;
    }
    
    public bool SelectLeftPressed()
    {
        if (!ControlsEnabled)
            return false;

        return Keyboard.current.leftArrowKey.wasPressedThisFrame;
    }

    public bool SelectUpPressed()
    {
        if (!ControlsEnabled)
            return false;

        return Keyboard.current.upArrowKey.wasPressedThisFrame;
    }

    public bool ConfirmPressed()
    {
        if (!ControlsEnabled)
            return false;

        return Keyboard.current.enterKey.wasPressedThisFrame;
    }
}
