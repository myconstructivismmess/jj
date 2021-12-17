using UnityEngine;
using UnityEngine.InputSystem;

namespace Input
{
    public class InputController : MonoBehaviour
    {
        public static InputController Instance { get; private set; }
        
        
        private PlayerInput _playerInput;

        private void Awake()
        {
            Instance = this;
            
            _playerInput = GetComponent<PlayerInput>();
        }

        private void Update()
        {
            switch (_playerInput.currentControlScheme)
            {
                case "KeyboardAndMouse":
                    inputType = InputType.KeyboardAndMouse;
                    break;
                case "Gamepad":
                    inputType = InputType.Gamepad;
                    break;
            }
        }
    
        public Vector2 cameraRotateInputValue { get; private set; } = Vector2.zero;
        public InputType inputType { get; private set; } = InputType.KeyboardAndMouse;
        public void OnRotateCamera(InputValue inputValue)
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
            if (inputValue.isPressed && !ReferenceEquals(InteractionController.Instance, null))
                InteractionController.Instance.Interact();
        }

        public bool isRunning { get; private set; }
        public void OnCharacterRunning(InputValue inputValue)
        {
            isRunning = inputValue.Get<float>() > 0.5f;
        }
    }
}
