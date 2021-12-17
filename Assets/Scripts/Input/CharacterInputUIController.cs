using UnityEngine;

namespace Input
{
    public class CharacterInputUIController : MonoBehaviour
    {
        public GameObject keyboardAndMouseGameObject;
        public GameObject gamepadGameObject;
        
        public GameObject interactControlKeyboardAndMouseGameObject;
        public GameObject interactControlGamepadGameObject;

        private void Update()
        {
            if (!ReferenceEquals(InputController.Instance, null))
            {
                switch (InputController.Instance.inputType)
                {
                    case InputType.KeyboardAndMouse:
                        keyboardAndMouseGameObject.SetActive(true);
                        gamepadGameObject.SetActive(false);

                        interactControlKeyboardAndMouseGameObject.SetActive(InteractionController.Instance is { canInteract: true });
                        break;
                    case InputType.Gamepad:
                        keyboardAndMouseGameObject.SetActive(false);
                        gamepadGameObject.SetActive(true);
                        
                        interactControlGamepadGameObject.SetActive(InteractionController.Instance is { canInteract: true });
                        break;
                }
            }
            else
            {
                keyboardAndMouseGameObject.SetActive(false);
                gamepadGameObject.SetActive(false);
            }
        }
    }
}
