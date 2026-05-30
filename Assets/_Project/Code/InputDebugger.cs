using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputDebugger : MonoBehaviour
{
    private MarioPartyControls controls;

    private void Awake()
    {
        controls = new MarioPartyControls();
    }

    private void OnEnable()
    {
        controls.Enable();

        controls.BoardGame.Roll.performed += OnRoll;
        controls.BoardGame.Confirm.performed += OnConfirm;
        controls.BoardGame.Cancel.performed += OnCancel;
        controls.BoardGame.Pause.performed += OnPause;
    }

    private void OnDisable()
    {
        controls.BoardGame.Roll.performed -= OnRoll;
        controls.BoardGame.Confirm.performed -= OnConfirm;
        controls.BoardGame.Cancel.performed -= OnCancel;
        controls.BoardGame.Pause.performed -= OnPause;

        controls.Disable();
    }

    private void OnRoll(InputAction.CallbackContext ctx)
    {
        Debug.Log("ROLL DICE Pressed");
    }

    private void OnConfirm(InputAction.CallbackContext ctx)
    {
        Debug.Log("CONFIRM Pressed");
    }

    private void OnCancel(InputAction.CallbackContext ctx)
    {
        Debug.Log("CANCEL Pressed");
    }

    private void OnPause(InputAction.CallbackContext ctx)
    {
        Debug.Log("PAUSE Pressed");
    }
}
