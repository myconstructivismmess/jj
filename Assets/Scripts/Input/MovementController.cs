using System;
using UnityEngine;

namespace Input
{
	[RequireComponent(typeof(CharacterController))]
	public class MovementController : MonoBehaviour
	{
		public static MovementController Instance { get; private set; }
		
		[Header("Translation")]
		public float walkSpeed = 8f;
		public float runSpeed = 15f;
		
		[Header("Rotation")]
		public float gamepadRotationSpeed = 5f;
		public float mouseRotationSpeed = 5f;
		public Transform cameraHolder;
		
		private CharacterController _characterController;
		private Transform _transform;
		
		private float _cameraRotationX = 90f;

		private void Awake()
		{
			Instance = this;
			
			_characterController = GetComponent<CharacterController>();
			_transform = transform;
		}

		private void Update()
		{
			if (!ReferenceEquals(InputController.Instance, null))
			{
				_characterController.Move(_transform.rotation * new Vector3(
					InputController.Instance.characterMoveInputValue.x * Time.deltaTime * (InputController.Instance.isRunning ? runSpeed : walkSpeed),
					0,
					InputController.Instance.characterMoveInputValue.y * Time.deltaTime * (InputController.Instance.isRunning ? runSpeed : walkSpeed)
				));

				_transform.localRotation = Quaternion.Euler(new Vector3(
					_transform.localRotation.eulerAngles.x,
					_transform.localRotation.eulerAngles.y
					+ InputController.Instance.cameraRotateInputValue.x
					* (InputController.Instance.inputType == InputType.Gamepad
						? gamepadRotationSpeed
						: mouseRotationSpeed)
					* Time.deltaTime,
					_transform.localRotation.eulerAngles.z
				));
				
				_cameraRotationX -= InputController.Instance.cameraRotateInputValue.y * (InputController.Instance.inputType == InputType.Gamepad ? gamepadRotationSpeed : mouseRotationSpeed) * Time.deltaTime;
				_cameraRotationX = Mathf.Clamp(_cameraRotationX, 10, 170);
			}

			cameraHolder.localRotation = Quaternion.Euler(new Vector3(_cameraRotationX, 0, 0));
		}
		
		public Ray GetViewRay()
		{
			Vector3 direction = Quaternion.Euler(
				_cameraRotationX + 90,
				_transform.localRotation.eulerAngles.y,
				0
			) * Vector3.back;
			
			return new Ray(cameraHolder.position, direction);
		}
	}
}