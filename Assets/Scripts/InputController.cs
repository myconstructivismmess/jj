using UnityEngine;
using UnityEngine.InputSystem;

public class InputController : MonoBehaviour
{
    public static InputController Instance;

    private void Awake()
    {
        Instance = this;
    }
    
    public Vector2 cameraRotateInputValue { get; private set; } = Vector2.zero;
    public void OnCameraRotate(InputValue inputValue)
    {
        cameraRotateInputValue = inputValue.Get<Vector2>();
    }

    public Vector2 characterMoveInputValue { get; private set; } = Vector2.zero;
    public void OnCharacterMove(InputValue inputValue)
    {
        characterMoveInputValue = inputValue.Get<Vector2>();
    }
    
    public void OnCharacterInteract(InputValue inputValue)
    {
        if (inputValue.isPressed)
        {
            Debug.Log("Interact");
        }
    }

    public bool isRunning { get; private set; }
    public void OnCharacterRunning(InputValue inputValue)
    {
        isRunning = inputValue.Get<float>() > 0.5f;
    }
}
