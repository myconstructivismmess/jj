using UnityEngine;

namespace Input
{
    public class CharacterInputUIController : MonoBehaviour
    {
        public GameObject keyboardAndMouseGameObject;
        public GameObject gamepadGameObject;

        private void Update()
        {
            if (!ReferenceEquals(InputController.Instance, null))
            {
                switch (InputController.Instance.inputType)
                {
                    case InputType.KeyboardAndMouse:
                        keyboardAndMouseGameObject.SetActive(true);
                        gamepadGameObject.SetActive(false);
                        break;
                    case InputType.Gamepad:
                        keyboardAndMouseGameObject.SetActive(false);
                        gamepadGameObject.SetActive(true);
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
