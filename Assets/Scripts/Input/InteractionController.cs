using UnityEngine;

namespace Input
{
	public class InteractionController : MonoBehaviour
	{
		public static InteractionController Instance { get; private set; }
		
		public LayerMask grabbableLayerMask;
		public bool canInteract;

		private void Awake()
		{
			Instance = this;
		}

		public void Interact()
		{
			if (!ReferenceEquals(GrabController.Instance, null))
			{
				if (GrabController.Instance.isGrabbing)
				{
					GrabController.Instance.Throw();
					return;
				}

				if (!ReferenceEquals(MovementController.Instance, null))
				{
					if (Physics.Raycast(MovementController.Instance.GetViewRay(), out RaycastHit raycastHit, GrabController.Instance.grabMaxDistance, grabbableLayerMask))
					{
						GrabController.Instance.Grab(raycastHit.collider.GetComponent<Grabbable>());
						return;
					}
				}
			}
		}

		private void Update()
		{
			if (!ReferenceEquals(GrabController.Instance, null))
			{
				if (GrabController.Instance.isGrabbing)
				{
					canInteract = true;
					return;
				}

				if (!ReferenceEquals(MovementController.Instance, null))
				{
					if (Physics.Raycast(MovementController.Instance.GetViewRay(), out RaycastHit raycastHit, GrabController.Instance.grabMaxDistance, grabbableLayerMask))
					{
						canInteract = true;
						return;
					}
				}
			}
			
			canInteract = false;
		}
	}
}